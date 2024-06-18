using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strategies
{
    public class ObstacleObjectPool : MonoBehaviour
    {
        public List<ObstaclePrefabByType> Obstacles;
        public int initialSize = 5;
        private Dictionary<ObstacleType,List<Obstacle>> _obstaclePool;
        // Start is called before the first frame update
        void Start()
        {
            _obstaclePool = new Dictionary<ObstacleType, List<Obstacle>>();
            _obstaclePool.Add(ObstacleType.SLIME_PLATFORM,new List<Obstacle>());
            
            foreach (var obstacle in Obstacles)
            {
                GameObject pref = obstacle.Prefab;
                if (_obstaclePool.TryGetValue(obstacle.ObstacleType, out var obstacles))
                {
                    for (int i = 0; i < initialSize; i++)
                    {
                        GameObject obstacleGo = Instantiate(pref,transform.position,Quaternion.identity);
                        obstacleGo.SetActive(false);
                        obstacles.Add(obstacleGo.GetComponent<Obstacle>());
                    }
                }
                
                
            }
        }
        
        public Obstacle GetObject(ObstacleType obstacleType)
        {
            if (_obstaclePool.TryGetValue(obstacleType, out var obstacles))
            {
                foreach (Obstacle obstacle in obstacles)
                {
                    if (!obstacle.gameObject.activeInHierarchy)
                    {
                        obstacle.gameObject.SetActive(true);
                        return obstacle;
                    }
                }
                
                
            }
            GameObject obstacleGo = Instantiate(Obstacles.First(o => o.ObstacleType == obstacleType).Prefab);
            Obstacle newObstacle = obstacleGo.GetComponent<Obstacle>();
            newObstacle.gameObject.SetActive(true);
            obstacles.Add(newObstacle);
            return newObstacle;
        }
        
        public void ReturnObject(GameObject obj)
        {
            obj.transform.position = transform.position;
            obj.SetActive(false);
        }
    }

    [Serializable]
    public class ObstaclePrefabByType
    {
        public ObstacleType ObstacleType;
        public GameObject Prefab;
    }
}
