using System;
using UnityEngine;

namespace Game.Mechanics.PLayer
{
    public class PlayerInput : MonoBehaviour
    {
        #region Fields

        [SerializeField] private KeyCode DroppingBombButton = KeyCode.Space;
        [SerializeField] private KeyCode PauseGameButton = KeyCode.Escape;

        private bool isPlayerInputActive;

        #endregion


        /// <summary>
        /// The event sets the movement vector for the player.
        /// </summary>
        public Action<Vector2> MoveEvent;

        /// <summary>
        /// An event triggered by pressing the bomb reset button.
        /// </summary>
        public Action DroppingBombEvent;

        /// <summary>
        /// An event triggered by pressing the pause button.
        /// </summary>
        public Action PauseGameEvent;

        private void Update()
        {
            if (!isPlayerInputActive) return;
            if (Input.GetKeyDown(DroppingBombButton)) DroppingBombEvent?.Invoke();
            if (Input.GetKeyDown(PauseGameButton)) PauseGameEvent?.Invoke();
            MoveEvent?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        
        /// <summary>
        /// Method specifying the possibility of entering.
        /// </summary>
        /// <param name="state">New state of the input system.</param>
        public void SetPlayerInputState(bool state) => isPlayerInputActive = state;
    }
}