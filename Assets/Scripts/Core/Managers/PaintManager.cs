using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Core
{
    public class PaintManager : MonoBehaviour
    {
        [SerializeField] private float maxPaint = 1000f;
        private SlimeManager[] allSlimes;

        private void Awake() 
        {
            allSlimes = FindObjectsOfType<SlimeManager>();    
        }

        private void Update() 
        {
            foreach (var slime in allSlimes)
            {
                var trailLength = GetTrailLength(slime.Trail);
                Debug.Log(slime.SlimeMainMaterial.name + ": " + (trailLength / maxPaint) * 100f + "%");
            }    
        }

        private float GetTrailLength(TrailRenderer trail)
        {
            var points = new Vector3[trail.positionCount]; 
            var count = trail.GetPositions(points);
        
            // If there are not at least 2 points .. well there is nothing to measure
            if(count < 2) return 0f;
        
            var length = 0f;
        
            // Store the first position 
            var start = points[0];

            // Iterate through the rest of positions
            for(var i = 1; i < count; i++)
            {
                // get the current position
                var end = points[i];
                // Add the distance to the last position
                // basically the same as writing
                //length += (end - start).magnitude;
                length += Vector3.Distance(start, end);
                // update the start position for the next iteration
                start = end;
            }

            return length;
        }
    }
}
