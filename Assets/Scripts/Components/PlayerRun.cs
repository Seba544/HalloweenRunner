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
        private bool _isDead;
        private IPlayerRunComponentModel _componentModel;
        private Rigidbody2D _rgbd;
        private Coroutine _playerStumblesAgainstObstacleCoroutine;

        private void Awake()
        {
            _currentSpeed = Speed;
            var builder = new PlayerRunComponentModelBuilder();
            builder.Create();
            _componentModel = builder.GetPlayerRunComponentModel();

            _componentModel.PropertyChanged += OnPropertyChanged;
            _componentModel.PlayerStumblesAgainstObstacle += OnPlayerStumblesAgainstObstacle;
        }

        private void OnPlayerStumblesAgainstObstacle()
        {
            if(_playerStumblesAgainstObstacleCoroutine!=null)
                StopCoroutine(_playerStumblesAgainstObstacleCoroutine);
            _playerStumblesAgainstObstacleCoroutine = StartCoroutine(ReduceSpeedCoroutine());
        }

        private IEnumerator ReduceSpeedCoroutine()
        {
            _componentModel.ReduceSpeed();
            yield return new WaitForSeconds(2f);
            _componentModel.ResumeSpeed();
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
        
        void Update()
        {
            if (Time.timeScale == 0 || _isDead)
                return;
            _rgbd.velocity = new Vector2(_currentSpeed, _rgbd.velocity.y);
        }

        private void OnDestroy()
        {
            _componentModel.PropertyChanged -= OnPropertyChanged;
            _componentModel.PlayerStumblesAgainstObstacle -= OnPlayerStumblesAgainstObstacle;
            _componentModel.Dispose();
        }
    }
}
