using System;
using UnityEngine;

namespace Components
{
    public class CandyVariation : MonoBehaviour
    {
        private string _candyVariationId;
        public CandyType CandyType;

        private void Awake()
        {
            _candyVariationId = Guid.NewGuid().ToString();
        }

        public string GetCandyVariationId() => _candyVariationId;
    }
    public enum CandyType
    {
        CANDY_X_1,
        CANDY_X_3,
        CANDY_X_5,
    }
}
