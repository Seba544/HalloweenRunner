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
        private Dictionary<CandyType,List<Candy>> _candyPool;

        private void Start()
        {
            _candyPool = new Dictionary<CandyType, List<Candy>>();
            _candyPool.Add(CandyType.CANDY,new List<Candy>());
            //pool = new List<GameObject>();
            foreach (var candy in Candies)
            {
                GameObject pref = candy.Prefab;
                if (_candyPool.TryGetValue(candy.CandyType, out var candyVariations))
                {
                    for (int i = 0; i < InitialSize; i++)
                    {
                        GameObject obj = Instantiate(pref,transform.position,Quaternion.identity);
                        Candy candyVariation = obj.GetComponent<Candy>();
                        obj.SetActive(false);
                        candyVariations.Add(candyVariation);
                    }
                }
                
                
            }
        }
        public Candy GetObject(CandyType candyType)
        {
            if (_candyPool.TryGetValue(candyType, out var candyVariations))
            {
                foreach (Candy candyVariation in candyVariations)
                {
                    if (!candyVariation.gameObject.activeInHierarchy)
                    {
                        candyVariation.gameObject.SetActive(true);
                        return candyVariation;
                    }
                }
                
                
            }
            GameObject newCandyVariationGo = Instantiate(Candies.First(c => c.CandyType == candyType).Prefab);
            Candy newCandyVariation = newCandyVariationGo.GetComponent<Candy>();
            newCandyVariationGo.SetActive(true);
            candyVariations.Add(newCandyVariation);
            return newCandyVariation;
        }
        public void ReturnObject(GameObject obj)
        {
            obj.transform.position = transform.position;
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