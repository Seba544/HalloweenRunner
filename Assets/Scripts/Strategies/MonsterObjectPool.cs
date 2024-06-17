using System;
using System.Collections.Generic;
using System.Linq;
using Components;
using UnityEngine;

namespace Strategies
{
    public class MonsterObjectPool : MonoBehaviour
    {
        public List<MonsterPrefabByType> Monsters;
        public int initialSize = 5;
        private Dictionary<MonsterType,List<Monster>> monsterPool;

        void Start()
        {
            monsterPool = new Dictionary<MonsterType, List<Monster>>();
            monsterPool.Add(MonsterType.ZOMBIE,new List<Monster>());
            monsterPool.Add(MonsterType.EVIL_BUG,new List<Monster>());
            //pool = new List<GameObject>();
            foreach (var monster in Monsters)
            {
                GameObject pref = monster.Prefab;
                if (monsterPool.TryGetValue(monster.MonsterType, out var monsters))
                {
                    for (int i = 0; i < initialSize; i++)
                    {
                        GameObject monsterGo = Instantiate(pref,transform.position,Quaternion.identity);
                        monsterGo.SetActive(false);
                        monsters.Add(monsterGo.GetComponent<Monster>());
                    }
                }
                
                
            }
        }

        public Monster GetObject(MonsterType monsterType)
        {
            if (monsterPool.TryGetValue(monsterType, out var monsters))
            {
                foreach (Monster monster in monsters)
                {
                    if (!monster.gameObject.activeInHierarchy)
                    {
                        monster.gameObject.SetActive(true);
                        return monster;
                    }
                }
                
                
            }
            GameObject monsterGo = Instantiate(Monsters.First(m => m.MonsterType == monsterType).Prefab);
            Monster newMonster = monsterGo.GetComponent<Monster>();
            newMonster.gameObject.SetActive(true);
            monsters.Add(newMonster);
            return newMonster;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.transform.position = transform.position;
            obj.SetActive(false);
        }
    }
    
    [Serializable]
    public class MonsterPrefabByType
    {
        public MonsterType MonsterType;
        public GameObject Prefab;
    }
}
