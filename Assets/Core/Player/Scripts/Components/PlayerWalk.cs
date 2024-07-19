using System;
using System.Collections;
using Core.Builder;
using Core.Player.Scripts.Controllers;
using UnityEngine;

namespace Core.Player.Scripts.Components
{
    public class PlayerWalk : MonoBehaviour,IPlayerWalk
    {
        private IPlayerWalkController _controller;
        [SerializeField] private Animator _animator;
        private Coroutine _playerStumblesAgainstObstacleCoroutine;

        private void Awake()
        {
            var builder = new PlayerWalkControllerBuilder(this);
            builder.Create();
            _controller = builder.GetPlayerWalkController();
        }

        public void Walk()
        {
            if(_playerStumblesAgainstObstacleCoroutine!=null)
                StopCoroutine(_playerStumblesAgainstObstacleCoroutine);
            _playerStumblesAgainstObstacleCoroutine = StartCoroutine(ReduceSpeedCoroutine());
        }
        private IEnumerator ReduceSpeedCoroutine()
        {
            _controller.ReduceSpeed();
            _animator.SetBool("isWalking",true);
            yield return new WaitForSeconds(2f);
            _controller.ResumeSpeed();
            _animator.SetBool("isWalking",false);
        }

        private void OnDestroy()
        {
            _controller.Dispose();
        }
    }
}
