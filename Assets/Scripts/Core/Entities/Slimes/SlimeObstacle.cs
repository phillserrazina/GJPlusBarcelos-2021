using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class SlimeObstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other) 
        {
            var slime = other.gameObject.GetComponent<SlimeManager>();
            if (slime != null)
            {
                if (slime.Mounted)
                    slime.Kill();
            }    
        }
    }
}
