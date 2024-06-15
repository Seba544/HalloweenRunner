using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    public class DisableObject : MonoBehaviour
    {
        private Coroutine _coroutine;
        private void OnEnable()
        {
            _coroutine = StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            StopCoroutine(_coroutine);
        }
    }
}
