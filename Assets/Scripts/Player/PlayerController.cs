using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public LayerMask groundMask; // Assign in Inspector to the layers that are considered ground
                                        // CharacterMovement Reference
        private ICharacterMovement _character;

        private float currentSpeed = 0f; // Velocidad actual del movimiento
        private float targetSpeed = 2f; // Velocidad objetivo al correr
        private float acceleration = 5f; // Tasa de aceleración
        private float deceleration = 5f; // Tasa de desaceleración
        
        
        public int FloorIndex { get; private set; }

        private void Start()
        {
            _character = new Character.Character(GetComponent<CharacterController>(), groundMask);
        }

            // Update is called once per frame
        void Update()
        {
            // Character movement vector
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (movementDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    targetSpeed = 2f;
                    currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
                }
                else
                {
                    targetSpeed = 1f;
                    currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
                }

                _character.Move(movementDirection * currentSpeed);
            }
            else
            {
                // Si no hay movimiento, desacelera hacia cero
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.deltaTime);
                _character.Move(movementDirection * currentSpeed);
            }
                

            // Changes the height position of the Character
            if (Input.GetButtonDown("Jump"))
            {
                _character.Jump();
            }

            // Ground Character all the time
            _character.GroundCharacter();
         }

        /*
         * The OnCollisionEnter function in Unity is used to detect collisions when .
         * The function is called when the Collider other enters the trigger.
        */

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Grass"))
            {
                FloorIndex = 0;
            }
            if (other.CompareTag("Mud"))
            {
                FloorIndex = 1;
            }
            if (other.CompareTag("Rock"))
            {
                FloorIndex = 2;
            }
            if (other.CompareTag("Wood"))
            {
                FloorIndex = 3;
            }
        }
        
    }
}


