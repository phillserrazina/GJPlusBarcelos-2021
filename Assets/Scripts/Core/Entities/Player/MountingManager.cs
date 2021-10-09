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
                
                return;
            }

            CurrentSlime = newSlime;

            player.transform.position = CurrentSlime.MountingPoint.position;
            player.GetComponent<Rigidbody>().useGravity = false;

            CurrentSlime.Movement.SetMovementActive(false);
        }
    }
}
