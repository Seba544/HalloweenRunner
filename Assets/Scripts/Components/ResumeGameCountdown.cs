using System;
using Builder;
using Components.Contracts;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Contracts;

namespace Components
{
    public class ResumeGameCountdown : MonoBehaviour, IResumeGameCountdown
    {
        
        private IResumeGameCountdownController _countdownComponentModel;
        public int CountdownValue;
        [SerializeField] private TMP_Text _countdownText;
        private void Awake()
        {
            var componentModelBuilder = new ResumeGameCountdownControllerBuilder(this);
            componentModelBuilder.Create();
            _countdownComponentModel = componentModelBuilder.GetComponentModel();

            _countdownComponentModel.InitCountdown += OnInitCountdown;
        }

        private void Start()
        {
            _countdownText.gameObject.SetActive(false);
        }

        private void OnInitCountdown()
        {
            _countdownText.gameObject.SetActive(true);
            DOTween.To(() => CountdownValue, x => {
                CountdownValue = x;
                _countdownText.text = CountdownValue.ToString();
            }, 0, CountdownValue).OnComplete(() => {
                _countdownText.gameObject.SetActive(false);
                FinishCountdown?.Invoke();
            });
        }


        public event Action FinishCountdown = () => {};
    }
}
