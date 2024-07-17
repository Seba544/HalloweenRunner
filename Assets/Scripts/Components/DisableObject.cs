using System;
using System.Collections;
using Assets.Scripts.Builder;
using Assets.Scripts.Components.Contracts;
using Assets.Scripts.Controllers;
using Strategies;
using UnityEngine;

namespace Components
{
    public class DisableObject : MonoBehaviour,IDisableObject
    {
        private IDisableObjectController _controller;
        private Coroutine _coroutine;
        private MonsterObjectPool _monsterObjectPool;
        public float Time;

        private void Awake()
        {
            var builder = new DisableObjectControllerBuilder(this);
            builder.Create();
            _controller = builder.GetDisableObjectController();

            _monsterObjectPool = FindObjectOfType<MonsterObjectPool>();
        }

        private void OnEnable()
        {
            _coroutine = StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            while (true)
            {
                yield return new WaitForSeconds(Time);
                _monsterObjectPool.ReturnObject(gameObject);
            }
        }


        public void GameOver()
        {
            StopCoroutine(_coroutine);
        }
        private void OnDestroy()
        {
            StopCoroutine(_coroutine);
            _controller.Dispose();
        }
    }
}
