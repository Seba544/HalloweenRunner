using System;
using System.ComponentModel;
using Builder;
using Component_Models.Contracts;
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

        private void Awake()
        {
            var builder = new MonsterComponentModelBuilder(Speed);
            builder.Create();
            _monsterComponentModel = builder.GetMonsterComponentModel();
            _monsterComponentModel.PropertyChanged += OnPropertyChanged;
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
            _monsterComponentModel.Init();
        }
        
        void FixedUpdate()
        {
            Debug.Log("Monster Speed: "+ _currentSpeed);
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
            _monsterComponentModel.Dispose();
        }
    }
}
