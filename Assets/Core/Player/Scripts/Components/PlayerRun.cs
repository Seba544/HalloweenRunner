using System;
using System.Collections;
using System.Collections.Generic;
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
        private float _newSpeed;
        private bool _isDead;
        private IPlayerRunController m_controller;
        private Rigidbody2D _rgbd;
        private Coroutine _playerStumblesAgainstObstacleCoroutine;
        private float _velocity = 0;

        private void Awake()
        {
            _currentSpeed = Speed;
            var builder = new PlayerRunControllerBuilder();
            builder.Create();
            m_controller = builder.GetPlayerRunComponentModel();

            m_controller.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(m_controller.CurrentSpeed))
            {
                _newSpeed = m_controller.CurrentSpeed;
                //_currentSpeed = _componentModel.CurrentSpeed;
            }

            if (e.PropertyName == nameof(m_controller.IsDead))
            {
                _isDead = m_controller.IsDead;
            }
        }

        void Start()
        {
            _rgbd = GetComponent<Rigidbody2D>();
            m_controller.Run();
        }
        
        void Update()
        {
            if (Time.timeScale == 0 || _isDead)
                return;
            _currentSpeed = Mathf.SmoothDamp(_currentSpeed, _newSpeed, ref _velocity, 0.1f);
            _rgbd.velocity = new Vector2(_currentSpeed, _rgbd.velocity.y);
        }

        private void OnDestroy()
        {
            m_controller.PropertyChanged -= OnPropertyChanged;
            m_controller.Dispose();
        }
    }
}
