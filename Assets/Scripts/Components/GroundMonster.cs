using System.ComponentModel;
using Builder;
using Component_Models.Contracts;
using Strategies;
using UnityEngine;

namespace Components
{
    public class GroundMonster : Monster
    {
        private IMonsterComponentModel _monsterComponentModel;
        private Animator _animator;
        private Rigidbody2D _rgbd;
        private float _currentSpeed;
        public float Speed;
        private MonsterObjectPool _monsterObjectPool;
        private Transform _spawnPoint;

        private void Awake()
        {
            
            _spawnPoint = GameObject.FindWithTag("ObjectSpawnPoint").transform;
            switch (MonsterType)
            {
                case MonsterType.ZOMBIE:
                    _monsterObjectPool = FindObjectOfType<MonsterObjectPool>();
                    break;
            }
            var builder = new MonsterComponentModelBuilder(Speed);
            builder.Create();
            _monsterComponentModel = builder.GetMonsterComponentModel();
            MonsterId = _monsterComponentModel.GetMonsterId();
            _monsterComponentModel.PropertyChanged += OnPropertyChanged;
            _monsterComponentModel.RelocateToSpawnPoint += OnRelocateToSpawnPoint;
        }

        private void OnRelocateToSpawnPoint(float posX, float posY, float posZ)
        {
            transform.position = new Vector3(posX, posY, posZ);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_monsterComponentModel.CurrentSpeed))
            {
                _currentSpeed = _monsterComponentModel.CurrentSpeed;
            }
        }
        
        void Start()
        {
            
            _rgbd = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
        }

        private void OnEnable()
        {
            _monsterComponentModel.Move();
        }

        private void OnDisable()
        {
            _monsterComponentModel.Stop();
        }

        void FixedUpdate()
        {
            if(Time.timeScale==0)
                Stop();
            
            if(_currentSpeed>0f)
                Move();
            else
                Stop();
            
        }

        public override void Move()
        {
            _animator.SetBool("isRunning",true);
            _rgbd.velocity = new Vector2(_currentSpeed * -1, _rgbd.velocity.y);
        }

        public override void Stop()
        {
            _animator.SetBool("isRunning",false);
            _rgbd.velocity = Vector2.zero;
        }

        private void OnDestroy()
        {
            _monsterComponentModel.PropertyChanged -= OnPropertyChanged;
            _monsterComponentModel.RelocateToSpawnPoint -= OnRelocateToSpawnPoint;
            _monsterComponentModel.Dispose();
        }
    }
}
