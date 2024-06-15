using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using UnityEngine;

namespace Strategies
{
    public class CandyObjectPool : MonoBehaviour
    {
        public List<CandyPrefabByType> Candies;
        public int InitialSize;
        private Dictionary<CandyType,List<CandyVariation>> _candyPool;

        private void Start()
        {
            _candyPool = new Dictionary<CandyType, List<CandyVariation>>();
            _candyPool.Add(CandyType.CANDY_X_1,new List<CandyVariation>());
            _candyPool.Add(CandyType.CANDY_X_3,new List<CandyVariation>());
            _candyPool.Add(CandyType.CANDY_X_5,new List<CandyVariation>());
            //pool = new List<GameObject>();
            foreach (var candy in Candies)
            {
                GameObject pref = candy.Prefab;
                if (_candyPool.TryGetValue(candy.CandyType, out var candyVariations))
                {
                    for (int i = 0; i < InitialSize; i++)
                    {
                        GameObject obj = Instantiate(pref,transform.position,Quaternion.identity);
                        CandyVariation candyVariation = obj.GetComponent<CandyVariation>();
                        obj.SetActive(false);
                        candyVariations.Add(candyVariation);
                    }
                }
                
                
            }
        }
        public CandyVariation GetObject(CandyType candyType)
        {
            if (_candyPool.TryGetValue(candyType, out var candyVariations))
            {
                foreach (CandyVariation candyVariation in candyVariations)
                {
                    if (!candyVariation.gameObject.activeInHierarchy)
                    {
                        candyVariation.gameObject.SetActive(true);
                        return candyVariation;
                    }
                }
                
                
            }
            GameObject newCandyVariationGo = Instantiate(Candies.First(c => c.CandyType == candyType).Prefab);
            CandyVariation newCandyVariation = newCandyVariationGo.GetComponent<CandyVariation>();
            newCandyVariationGo.SetActive(true);
            candyVariations.Add(newCandyVariation);
            return newCandyVariation;
        }
        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }

    [Serializable]
    public class CandyPrefabByType
    {
        public CandyType CandyType;
        public GameObject Prefab;
    }
}