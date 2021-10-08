using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class PlayerMovement : CharacterMovement
    {
        // VARIABLES
        [SerializeField] private float mountedSpeed = 1000f;
        [SerializeField] private float mouseSensitivity = 5f;
        [SerializeField] private float mountedTurnedSensitivity = 5f;

        // METHODS
        protected override void GetInput()
        {
            verticalDirection = Input.GetAxisRaw("Vertical");
            horizontalDirection = Input.GetAxisRaw("Horizontal");

            if (((PlayerManager)manager).Mounted)
            {
                transform.Rotate(0f, horizontalDirection * mountedTurnedSensitivity * Time.deltaTime, 0f, Space.World);
                return;
            }

            transform.Rotate(0f, (Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime), 0, Space.World);
        }

        protected override void Move()
        {
            if (((PlayerManager)manager).Mounted)
            {
                rb.velocity = transform.forward * mountedSpeed * Time.fixedDeltaTime;
                return;
            }

            var velocity = ((transform.right * horizontalDirection) + 
                            (transform.forward * verticalDirection)) * 
                            movementSpeed * Time.fixedDeltaTime;

            velocity.y = rb.velocity.y;

            rb.velocity = velocity;
        }
    }
}
