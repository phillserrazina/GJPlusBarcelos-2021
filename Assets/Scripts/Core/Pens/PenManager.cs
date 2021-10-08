using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class PenManager : MonoBehaviour
    {
        // VARIABLES
        private Pen[] pens;

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            pens = FindObjectsOfType<Pen>();    
        }

        private void Update() 
        {
            if (!GameManager.Instance.IsPlaying)
                return;

            foreach (var pen in pens)
            {
                if (!pen.Complete)
                    return;
            }    

            GameManager.Instance.WinWithDelay(1f);
        }
    }
}
