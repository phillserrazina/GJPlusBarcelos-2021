using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class PlayerMovement : CharacterMovement
    {
        // VARIABLES
        [SerializeField] private float mouseSensitivity = 5f;

        // METHODS
        protected override void GetInput()
        {
            verticalDirection = Input.GetAxisRaw("Vertical");
            horizontalDirection = Input.GetAxisRaw("Horizontal");

            transform.Rotate(0f, (Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime), 0, Space.World);
        }

        protected override void Move()
        {
            rb.velocity = ((transform.right * horizontalDirection) + 
                            (transform.forward * verticalDirection)) * 
                            movementSpeed * Time.fixedDeltaTime;
        }
    }
}
