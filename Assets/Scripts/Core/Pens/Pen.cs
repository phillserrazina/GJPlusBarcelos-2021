using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Slime.Core
{
    public class Pen : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private Material penMaterial;
        public Material PenMaterial => penMaterial;

        public bool Complete => slimesInside.Count == existingSlimes.Count;

        private List<SlimeManager> slimesInside = new List<SlimeManager>();
        private List<SlimeManager> existingSlimes = new List<SlimeManager>();

        private TextMesh penTextMesh;

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            GetComponentInChildren<PenDoor>().Initialize(this);
            existingSlimes = FindObjectsOfType<SlimeManager>().Where(slime => slime.SlimeMainMaterial == penMaterial).ToList();

            penTextMesh = GetComponentInChildren<TextMesh>();
        }

        private void Update() 
        {
            penTextMesh.text = $"{slimesInside.Count}/{existingSlimes.Count}";
        }

        // METHODS
        public void OnSlimeEnter(SlimeManager newSlime)
        {
            slimesInside.Add(newSlime);
            newSlime.Animation.SetTrigger("Win");
            newSlime.SetPen(this);
            MountingManager.Instance.SetAsCurrentSlime(null);
        }

        public void OnSlimeExit(SlimeManager newSlime)
        {
            slimesInside.Remove(newSlime);
        }

        public bool SlimeIsInside(SlimeManager slime) => slimesInside.Contains(slime);
    }
}
