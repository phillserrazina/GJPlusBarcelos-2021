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

        public TrailRenderer Trail { get; private set; }

        public Material SlimeMainMaterial => slimeMainMaterial;
        public Transform MountingPoint => mountingPoint;

        protected bool mounted => MountingManager.Instance.CurrentSlime == this;

        // EXECUTION FUNCTIONS
        private void Update() 
        {
            if (mounted)
            {
                transform.rotation = FindObjectOfType<PlayerManager>().transform.rotation;
            }
        }

        // METHODS
        protected override void Initialize()
        {
            base.Initialize();
            Trail = GetComponentInChildren<TrailRenderer>();
        }
    }
}
