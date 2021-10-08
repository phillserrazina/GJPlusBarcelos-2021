using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime.Core.Components;

namespace Slime.Core
{
    public class CharacterManager : MonoBehaviour
    {
        // VARIABLES
        public CharacterMovement Movement { get; private set; }

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            Initialize();
        }

        // METHODS
        protected virtual void Initialize()
        {
            Movement = GetComponent<CharacterMovement>();
            Movement.Initialize(this);
        }
    }
}
