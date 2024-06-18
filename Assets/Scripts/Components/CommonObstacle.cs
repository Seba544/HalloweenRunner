using System;
using Builder;
using Component_Models.Contracts;
using UnityEngine;

namespace Components
{
    public class CommonObstacle : Obstacle
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Collides against obstacle");
                _componentModel.CollidesWithPlayer(false);       
            }
        }

        private void OnDestroy()
        {
            _componentModel.RelocateToSpawnPoint -= OnRelocateToSpawnPoint;
            _componentModel.Dispose();
        }
    }
}
