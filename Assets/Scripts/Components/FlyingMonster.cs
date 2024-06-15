using System;
using System.ComponentModel;
using Builder;
using Component_Models.Contracts;
using Strategies;
using UnityEngine;

namespace Components
{
    public class FlyingMonster : Monster
    {
        private IMonsterComponentModel _componentModel;
        public float Speed;
        private float _currentSpeed;
        private Rigidbody2D _rgbd;
        public float DistanceFromGround;
        private MonsterObjectPool _monsterObjectPool;
        private void Awake()
        {
            _monsterObjectPool = FindObjectOfType<MonsterObjectPool>();
            var builder = new MonsterComponentModelBuilder(Speed);
            builder.Create();
            _componentModel = builder.GetMonsterComponentModel();
            MonsterId = _componentModel.GetMonsterId();
            _componentModel.PropertyChanged += OnPropertyChanged;
            _componentModel.RelocateToSpawnPoint += OnRelocateToSpawnPoint;
        }

        private void OnRelocateToSpawnPoint(float posX, float posY, float posZ)
        {
            transform.position = new Vector3(posX, posY, posZ);
            SetFlyHeight();
        }

        private void Start()
        {
            _rgbd = GetComponent<Rigidbody2D>();
            _componentModel.Move();
        }

        private void SetFlyHeight()
        {
            transform.position = new Vector3(transform.position.x,transform.position.y+DistanceFromGround,0);
        }

        private void Update()
        {
            if(Time.timeScale == 0)
                Stop();
            
            if(_currentSpeed>0f)
                Move();
            else
                Stop();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_componentModel.CurrentSpeed))
            {
                _currentSpeed = _componentModel.CurrentSpeed;
            }
        }

        public override void Move()
        {
            _rgbd.velocity = new Vector2(_currentSpeed * -1, _rgbd.velocity.y);
        }

        public override void Stop()
        {
            _rgbd.velocity = Vector2.zero;
        }

        private void OnEnable()
        {
            _componentModel.Move();
        }

        private void OnDisable()
        {
            _componentModel.Stop();
            _monsterObjectPool.ReturnObject(gameObject);
        }

        private void OnDestroy()
        {
            _componentModel.PropertyChanged -= OnPropertyChanged;
            _componentModel.RelocateToSpawnPoint -= OnRelocateToSpawnPoint;
            _componentModel.Dispose();
        }
    }
}
