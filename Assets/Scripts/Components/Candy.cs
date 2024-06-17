using System;
using System.Collections.Generic;
using Builder;
using Component_Models.Contracts;
using Strategies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class Candy : MonoBehaviour
    {
        private string _candyId;
        private ICandyComponentModel _componentModel;
        private CandyObjectPool _candyObjectPool;
        public CandyType CandyType;
        [SerializeField] private int Amount;
        public List<HeightLevelSpawnPosition> HeightLevels;
        private void Awake()
        {
            _candyObjectPool = FindObjectOfType<CandyObjectPool>();
            var builder = new CandyComponentModelBuilder(Amount);
            builder.Create();
            _componentModel = builder.GetCandyComponentModel();
            _candyId = _componentModel.GetCandyId();
            _componentModel.RelocateToSpawnPoint += OnRelocateToSpawnPoint;
        }

        private void OnRelocateToSpawnPoint(float posX, float posY, float posZ)
        {
            transform.position = new Vector3(posX, posY, posZ);
            SetVerticalSpawnPosition();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _componentModel.CollectCandy();
                _candyObjectPool.ReturnObject(gameObject);
            }
        }

        public string GetCandyId() => _candyId;
        private void SetVerticalSpawnPosition()
        {
            var heightLevel = HeightLevels[Random.Range(0, HeightLevels.Count)];
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + heightLevel.OffsetY, 0);
        }

        private void OnDestroy()
        {
            _componentModel.RelocateToSpawnPoint -= OnRelocateToSpawnPoint;
            _componentModel.Dispose();
        }
    
    }

    public enum CandyType
    {
        CANDY,
        SUPER_CANDY
    }
    [Serializable]
    public class HeightLevelSpawnPosition
    {
        public HeightLevel HeightLevel;
        public float OffsetY;
    }

    public enum HeightLevel
    {
        LOW,
        MIDDLE,
        HIGH
    }
}