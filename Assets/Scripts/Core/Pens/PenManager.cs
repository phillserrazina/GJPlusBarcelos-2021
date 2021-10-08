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
    }
}
