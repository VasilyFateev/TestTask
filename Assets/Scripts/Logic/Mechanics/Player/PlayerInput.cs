using System;
using UnityEngine;

namespace Game.Mechanics
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyCode DroppingBombButton = KeyCode.Space;
        
        
        /// <summary>
        /// The event sets the movement vector for the player.
        /// </summary>
        public Action<Vector2> MoveEvent;
        /// <summary>
        /// An event triggered by pressing the bomb reset button.
        /// </summary>
        public Action DroppingBombEvent;

        private void Update()
        {
            MoveEvent?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            if (Input.GetKeyDown(DroppingBombButton)) DroppingBombEvent?.Invoke();
        }
    }
}