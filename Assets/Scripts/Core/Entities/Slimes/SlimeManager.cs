using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class SlimeManager : CharacterManager
    {
        // VARIABLES
        [SerializeField] private Material slimeMainMaterial;
        [SerializeField] private Transform mountingPoint;

        public Material SlimeMainMaterial => slimeMainMaterial;
        public Transform MountingPoint => mountingPoint;

        protected bool mounted => MountingManager.Instance.CurrentSlime == this;

        // EXECUTION FUNCTIONS
        private void Update() 
        {
            if (mounted)
            {
                var newPos = FindObjectOfType<PlayerManager>().transform.position;
                newPos.y = transform.position.y;
                
                transform.position = newPos;
                transform.rotation = FindObjectOfType<PlayerManager>().transform.rotation;
            }
        }
    }
}
