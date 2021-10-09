using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class PlayerMovement : CharacterMovement
    {
        // VARIABLES
        [SerializeField] private float mountedSpeed = 1000f;
        [SerializeField] private float mountedTurnedSensitivity = 5f;

        [Space(10)]
        [SerializeField] private float horizontalMouseSensitivity = 5f;
        [SerializeField] private float verticalMouseSensitivity = 5f;

        [Header("References")]
        [SerializeField] private Transform lookAtPivot;

        // METHODS
        protected override void GetInput()
        {
            verticalDirection = Input.GetAxisRaw("Vertical");
            horizontalDirection = Input.GetAxisRaw("Horizontal");

            if (((PlayerManager)manager).Mounted)
            {
                lookAtPivot.localEulerAngles = Vector3.zero;
                transform.Rotate(0f, horizontalDirection * mountedTurnedSensitivity * Time.deltaTime, 0f, Space.World);
                return;
            }

            lookAtPivot.Rotate((Input.GetAxis("Mouse Y") * verticalMouseSensitivity * Time.deltaTime), 0f, 0f, Space.Self);

            var pivotRotation = lookAtPivot.localEulerAngles;
            
            if (pivotRotation.x > 180 && pivotRotation.x < 340)
            {
                pivotRotation.x = 340;
            }
            else if (pivotRotation.x < 180 && pivotRotation.x > 40)
            {
                pivotRotation.x = 40;
            }

            lookAtPivot.localEulerAngles = pivotRotation;

            transform.Rotate(0f, (Input.GetAxis("Mouse X") * horizontalMouseSensitivity * Time.deltaTime), 0f, Space.World);
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
