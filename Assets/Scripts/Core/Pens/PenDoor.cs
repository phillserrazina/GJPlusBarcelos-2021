using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class PenDoor : MonoBehaviour
    {
        // VARIABLES
        private Pen owner;

        // EXECUTION FUNCTIONS
        private void OnTriggerEnter(Collider other) 
        {
            var slime = other.GetComponent<SlimeManager>();
            if (slime != null)
            {
                if (slime.SlimeMainMaterial != owner.PenMaterial)
                    return;

                if (owner.SlimeIsInside(slime))
                    owner.OnSlimeExit(slime);
                else
                    owner.OnSlimeEnter(slime);
            }    
        }

        // METHODS
        public void Initialize(Pen owner)
        {
            this.owner = owner;
        }
    }
}
