using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class MountingManager : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private AudioSource fastMusicSource;

        private PlayerManager player;
        public SlimeManager CurrentSlime { get; private set; }

        public static MountingManager Instance { get; private set; }

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            Instance = this;
            player = FindObjectOfType<PlayerManager>();
        }

        // METHODS
        public void SetAsCurrentSlime(SlimeManager newSlime)
        {
            if (newSlime == null)
            {
                CurrentSlime.Movement.SetMovementActive(true);
                CurrentSlime.Animation.SetBool("Running", false);
                CurrentSlime = null;

                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<Collider>().enabled = true;

                player.Animation.SetTrigger("Mount");
                
                fastMusicSource.volume = 0f;

                return;
            }

            CurrentSlime = newSlime;

            player.GetComponent<Collider>().enabled = false;

            player.transform.position = CurrentSlime.MountingPoint.position;
            player.GetComponent<Rigidbody>().useGravity = false;

            player.Animation.SetTrigger("Mount");
            CurrentSlime.Animation.SetBool("Running", true);

            CurrentSlime.Movement.SetMovementActive(false);
            fastMusicSource.volume = 0.1f;
        }
    }
}
