using UnityEngine;

namespace Interfaces {
    public interface ICharacterMovement
    {
        public CharacterController controller { get; set; }
        
        /// <summary>
        /// Move character in the given direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector3 direction);

        /// <summary>
        /// Character Jumps
        /// </summary>
        public void Jump();

        /// <summary>
        /// Grounds the character
        /// </summary>
        public void GroundCharacter();

        /// <summary>
        /// Checks if character is grounded
        /// </summary>
        public bool IsGrounded();
    }
}