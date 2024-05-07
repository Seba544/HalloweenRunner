using System;
using UnityEngine;

namespace Modules.Player.Scripts
{
    public class Jump : MonoBehaviour,IJump
    {
        private JumpVM _jumpVM;

        private void Start()
        {
            _jumpVM = new JumpVM(this, new InMemoryPlayerRepository());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpAction?.Invoke();
            }
        }

        public event Action JumpAction = () => { };
    }
}
