using System;
using Builder;
using UnityEngine;

namespace Modules.Player.Scripts
{
    public class Jump : MonoBehaviour
    {
        private IJumpController _jumpController;
        private bool _isPlayerAbleToJump;
        private bool _isPlayerSliding;
        BoxCollider2D _boxCollider;
        private Animator _animator;
        private Rigidbody2D _rgbd;
        float _initialColliderSizeY;
        float _initialColliderOffsetY;
        public float JumpForce;

        private void Start()
        {
            _rgbd = GetComponent<Rigidbody2D>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
            _initialColliderSizeY = _boxCollider.size.y;
            _initialColliderOffsetY = _boxCollider.offset.y;
            _isPlayerAbleToJump = true;

            var componentModelBuilder = new JumpControllerBuilder();
            componentModelBuilder.Create();
            _jumpController = componentModelBuilder.GetController();
            
            _jumpController.DoJump += DoJump;
        }

        private void DoJump()
        {
            _boxCollider.size = new Vector2(_boxCollider.size.x, _initialColliderSizeY);
            _boxCollider.offset = new Vector2(_boxCollider.offset.x, _initialColliderOffsetY);
            _animator.SetTrigger("isJumping");
            _rgbd.velocity = new Vector2(_rgbd.velocity.x, JumpForce);
            //_audio.PlayOneShot(JumpAudioClip);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpController.Jump();
            }
        }

        private void OnDestroy()
        {
            _jumpController.Dispose();
        }


        public event Action JumpInputAction = () => { };
    }
}
