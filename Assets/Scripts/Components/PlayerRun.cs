using System;
using System.ComponentModel;
using Builder;
using Component_Models;
using Component_Models.Contracts;
using UnityEngine;

namespace Components
{
    public class PlayerRun : MonoBehaviour
    {
        public float Speed;
        private float _currentSpeed;
        private bool _isDead;
        private IPlayerRunComponentModel _componentModel;
        private Rigidbody2D _rgbd;

        private void Awake()
        {
            _currentSpeed = Speed;
            var builder = new PlayerRunComponentModelBuilder();
            builder.Create();
            _componentModel = builder.GetPlayerRunComponentModel();

            _componentModel.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_componentModel.CurrentSpeed))
            {
                _currentSpeed = _componentModel.CurrentSpeed;
            }

            if (e.PropertyName == nameof(_componentModel.IsDead))
            {
                _isDead = _componentModel.IsDead;
            }
        }

        void Start()
        {
            _rgbd = GetComponent<Rigidbody2D>();
            _componentModel.Run(Speed);
        }
        
        void FixedUpdate()
        {
            if (Time.timeScale == 0 || _isDead)
                return;
            _rgbd.velocity = new Vector2(_currentSpeed, _rgbd.velocity.y);
        }

        private void OnDestroy()
        {
            _componentModel.Dispose();
        }
    }
}
