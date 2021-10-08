using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core.Components
{
    public class PlayerSlimeDetector : CharacterComponent
    {
        private SlimeManager currentNearbySlime;

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (((PlayerManager)manager).Mounted)
                {
                    MountingManager.Instance.SetAsCurrentSlime(null);
                }

                if (currentNearbySlime != null)
                {
                    MountingManager.Instance.SetAsCurrentSlime(currentNearbySlime);
                    currentNearbySlime = null;
                }
            }

            
        }

        private void OnTriggerEnter(Collider other) 
        {
            var slime = other.GetComponent<SlimeManager>();
            if (slime != null)
            {
                currentNearbySlime = slime;
            }    
        }

        private void OnTriggerExit(Collider other) 
        {
            var slime = other.GetComponent<SlimeManager>();
            if (slime != null)
            {
                if (slime == currentNearbySlime)
                {
                    currentNearbySlime = null;
                }
            }    
        }
    }
}
