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
                transform.position = FindObjectOfType<PlayerManager>().transform.position + Vector3.down;
                transform.rotation = FindObjectOfType<PlayerManager>().transform.rotation;
            }
        }
    }
}
