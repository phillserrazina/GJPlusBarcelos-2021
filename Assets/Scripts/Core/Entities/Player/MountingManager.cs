using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class MountingManager : MonoBehaviour
    {
        private PlayerManager player;
        public SlimeManager CurrentSlime { get; private set; }

        public static MountingManager Instance { get; private set; }

        private void Awake() 
        {
            Instance = this;
            player = FindObjectOfType<PlayerManager>();
        }

        public void SetAsCurrentSlime(SlimeManager newSlime)
        {
            if (newSlime == null)
            {
                CurrentSlime.Movement.SetMovementActive(true);
                CurrentSlime = null;

                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<Collider>().enabled = true;
                
                return;
            }

            CurrentSlime = newSlime;

            player.GetComponent<Collider>().enabled = false;

            player.transform.position = CurrentSlime.MountingPoint.position;
            player.GetComponent<Rigidbody>().useGravity = false;

            CurrentSlime.Movement.SetMovementActive(false);
        }
    }
}
