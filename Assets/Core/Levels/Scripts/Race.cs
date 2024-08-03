using System;
using System.Collections;
using Builder.Controllers;
using UnityEngine;

namespace Core.Levels.Scripts
{
    public class Race : MonoBehaviour,IRace
    {
        private float raceTimeElapsed;
        [SerializeField] private float raceDuration;

        private IRaceController _controller;

        private Coroutine _raceCoroutine;

        private void Awake()
        {
            var builder = new RaceControllerBuilder(this);
            builder.Create();
            _controller = builder.GetRaceController();
        }

        private void Start()
        {
            StartRace();
        }

        private IEnumerator RaceCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                raceTimeElapsed++;
                Debug.Log("% RACE TIME ELAPSED: " + raceTimeElapsed);
                if (Mathf.Approximately(raceTimeElapsed, 60f))
                {
                    _controller.SetRaceDifficultyToMedium();
                }
                else if (Mathf.Approximately(raceTimeElapsed, 180f))
                {
                    _controller.SetRaceDifficultyToHard();
                }
                else if (Mathf.Approximately(raceTimeElapsed,raceDuration))
                {
                    _controller.EndRace();
                }
            }
        }

        public void StartRace()
        {
            _controller.StartRace();
            _raceCoroutine = StartCoroutine(RaceCoroutine());
        }

        public void EndRace()
        {
            if(_raceCoroutine!=null)
                StopCoroutine(_raceCoroutine);
        }
    }
}
