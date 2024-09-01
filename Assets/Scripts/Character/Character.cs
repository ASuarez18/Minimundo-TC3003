using System.Collections;
using Interfaces;
using TMPro;
using UnityEngine;

namespace Character
{
    public class Character : ICharacterMovement
    {
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private float PlayerSpeed = 2.0f;
        private float JumpHeight = 0.5f;
        private float GravityValue = -9.81f;

        // Animation for characters
        private readonly AnimatorController _animator;
        // Name of animation parameters
        private const string Fordward = "Forward";
        private const string Side = "Side";
        private const string RandomAnimation = "Jump";

        private readonly int _randomHash = Animator.StringToHash("UMATOBI00");
        public CharacterController controller { get; set; }
        public LayerMask groundMask; // Assign in Inspector to the layers that are considered ground

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="characterController"></param>
        public Character(CharacterController characterController, LayerMask groundLayerMask)
        {
            controller = characterController;
            groundMask = groundLayerMask;

            // New AnimatorController
            _animator = new AnimatorController();
            _animator.Animator = controller.GetComponentInChildren<Animator>();
        }

        protected Character()
        {

        }

        public void Move(Vector3 direction)
        {
            // COnverts the direction from local to world space so the character moves in the correct direction
            var localDirection = controller.transform.TransformDirection(direction);
            // Moves the character in the given direction
            controller.Move(localDirection * Time.deltaTime * PlayerSpeed);

            // Rotate the player towards the direction it is moving
            controller.transform.Rotate(Vector3.up, direction.x * 0.5f, Space.World);

            // Play the walk animations
            _animator.SetFloat(Fordward, direction.z);
            _animator.SetFloat(Side, direction.x);
        }

        public void Jump()
        {
            // If is already jumping, return
            if (!IsGrounded() || _playerVelocity.y > 0)
                return;

            JumpAfterDelay();

            // Play the jump animation
            _animator.SetTrigger(RandomAnimation);
            _animator.PlayAnimationByHash(_randomHash);
            //_animator.SetTrigger(RandomAnimation);
        }

        public void GroundCharacter()
        {
            if (IsGrounded() && _playerVelocity.y < 0)
            {
                // Moves the player down
                _playerVelocity.y = 0;
                return;
            }
            _playerVelocity.y += GravityValue * Time.deltaTime;
            controller.Move(_playerVelocity * Time.deltaTime);
        }

        public bool IsGrounded()
        {
            // This offers innacurate results
            // return controller.isGrounded;

            // Implement a raycast to check if the character is grounded
            // Draw a raycast from the player's position to the ground to check the distance
            Debug.DrawRay(controller.transform.position, Vector3.down * 0.05f, Color.red);

            // Check if the raycast hits the ground layer
            return Physics.Raycast(controller.transform.position, Vector3.down, out RaycastHit hit, 0.05f, groundMask);

        }

        IEnumerator JumpAfterDelay()
        {
            yield return new WaitForSeconds(1f); // Espera 1 segundo
            // Moves the character in the given direction
            _playerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * GravityValue);
            controller.Move(_playerVelocity * Time.deltaTime);

        }
    }
}