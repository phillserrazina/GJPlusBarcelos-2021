using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class CharacterMovement : CharacterComponent
    {
        // VARIABLES
        [Header("Settings")]
        [SerializeField] protected float movementSpeed = 500f;

        private bool canMove = true;

        protected float verticalDirection;
        protected float horizontalDirection;

        protected Rigidbody rb;

        // EXECUTION FUNCTIONS
        private void Update() 
        {
            if (canMove && GameManager.Instance.IsPlaying)
                GetInput();    
        }

        private void FixedUpdate() 
        {
            if (canMove && GameManager.Instance.IsPlaying)
                Move();
            else
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime);
        }

        // METHODS
        public override void Initialize(CharacterManager manager)
        {
            base.Initialize(manager);

            rb = GetComponent<Rigidbody>();
        }

        protected virtual void GetInput()
        {
            Debug.LogWarning("CharacterMovement::GetInput() --- Non-implemented function.");
        }

        protected virtual void Move()
        {
            Debug.LogWarning("CharacterMovement::Move() --- Non-implemented function.");
        }

        public virtual void SetMovementActive(bool value)
        {
            canMove = value;
        }
    }
}
