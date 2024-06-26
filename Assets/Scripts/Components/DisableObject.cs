using System;
using System.Collections;
using Strategies;
using UnityEngine;

namespace Components
{
    public class DisableObject : MonoBehaviour
    {
        private Coroutine _coroutine;
        private MonsterObjectPool _monsterObjectPool;
        public float Time;

        private void Awake()
        {
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

        private void OnDestroy()
        {
            StopCoroutine(_coroutine);
        }
    }
}
