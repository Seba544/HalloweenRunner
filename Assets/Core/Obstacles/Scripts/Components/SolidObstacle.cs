using System;
using Builder;
using Component_Models.Contracts;
using UnityEngine;

namespace Core.Obstacles.Scripts.Components
{
    public class SolidObstacle : Obstacle
    {
        private IObstacleComponentModel _componentModel;
        private void Awake()
        {
            var builder = new ObstacleComponentModelBuilder();
            builder.Create();
            _componentModel = builder.GetObstacleComponentModel();
            _obstacleId = _componentModel.GetObstacleId();

            _componentModel.RelocateToSpawnPoint += OnRelocateToSpawnPoint;
        }

        private void OnRelocateToSpawnPoint(float posX, float posY, float posZ)
        {
            transform.position = new Vector3(posX, posY, posZ);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("SNAIL COLLIDES WITH PLAYER");
                _componentModel.CollidesWithPlayer(true); 
            }
        }

        private void OnDestroy()
        {
            _componentModel.RelocateToSpawnPoint -= OnRelocateToSpawnPoint;
            _componentModel.Dispose();
        }
    }
}
