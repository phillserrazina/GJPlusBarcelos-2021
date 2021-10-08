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
                
                return;
            }

            CurrentSlime = newSlime;

            player.transform.position = CurrentSlime.MountingPoint.position;

            CurrentSlime.Movement.SetMovementActive(false);
        }
    }
}
