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
                //Debug.Log(slime.SlimeMainMaterial.name + ": " + (trailLength / maxPaint) * 100f + "%");
            }    
        }

        private float GetTrailLength(TrailRenderer trail)
        {
            var points = new Vector3[trail.positionCount]; 
            var count = trail.GetPositions(points);
        
            if(count < 2) return 0f;
        
            var length = 0f;
        
            var start = points[0];

            for(var i = 1; i < count; i++)
            {
                var end = points[i];
                length += Vector3.Distance(start, end);
                start = end;
            }

            return length;
        }
    }
}
