using System;
using Builder.Controllers;
using Core.Player.Scripts.Controllers;
using Core.Player.Scripts.Data;
using UnityEngine;

namespace Core.Player.Scripts.Components
{
    public class PlayerInitializer : MonoBehaviour
    {
        private IPlayerInitializerController _controller;
        [SerializeField] private PlayerSO _playerData;

        private void Awake()
        {
            var builder = new PlayerInitializerControllerBuilder();
            builder.Create();
            _controller = builder.GetPlayerInitializerController();
            _controller.InitPlayer(_playerData.RunSpeed,_playerData.WalkSpeed);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
