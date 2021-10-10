using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class SlimeManager : CharacterManager
    {
        // VARIABLES
        [SerializeField] private Material slimeMainMaterial;
        [SerializeField] private ParticleSystem deathFX;
        [SerializeField] private Transform mountingPoint;
        [SerializeField] private AudioSource deathAudioSource;
        private AudioSource winSource;

        public TrailRenderer Trail { get; private set; }

        public Material SlimeMainMaterial => slimeMainMaterial;
        public Transform MountingPoint => mountingPoint;

        public bool Mounted => MountingManager.Instance.CurrentSlime == this;

        public Pen Pen { get; private set; }

        // EXECUTION FUNCTIONS
        private void Update() 
        {
            if (Mounted)
            {
                transform.rotation = FindObjectOfType<PlayerManager>().transform.rotation;
            }
        }

        // METHODS
        protected override void Initialize()
        {
            base.Initialize();
            Trail = GetComponentInChildren<TrailRenderer>();
            winSource = GetComponent<AudioSource>();
        }

        public void Kill()
        {
            Trail.transform.parent = null;
            MountingManager.Instance.SetAsCurrentSlime(null);
            Instantiate(deathFX, transform.position, deathFX.transform.rotation);
            
            deathAudioSource.pitch = Random.Range(0.9f, 1.1f);
            deathAudioSource.Play();
            Destroy(gameObject);
        }

        public void SetPen(Pen pen)
        {
            Pen = pen;
            winSource.Play();
        }
    }
}
