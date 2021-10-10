using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Slime.Core
{
    public class Pen : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private int minimumNeededSlimes = 1;
        [SerializeField] private Material penMaterial;
        public Material PenMaterial => penMaterial;

        public bool Complete => slimesInside.Count == minimumNeededSlimes;

        private List<SlimeManager> slimesInside = new List<SlimeManager>();
        private List<SlimeManager> existingSlimes = new List<SlimeManager>();

        private TextMesh penTextMesh;

        // EXECUTION FUNCTIONS
        private void Awake() 
        {
            GetComponentInChildren<PenDoor>().Initialize(this);
            existingSlimes = FindObjectsOfType<SlimeManager>().Where(slime => slime.SlimeMainMaterial == penMaterial).ToList();

            foreach (var slime in existingSlimes)
            {
                slime.SetSupposedPen(this);
            }

            penTextMesh = GetComponentInChildren<TextMesh>();
        }

        private void Update() 
        {
            penTextMesh.text = $"{slimesInside.Count}/{minimumNeededSlimes}";
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

        public void RemoveSlive(SlimeManager slime)
        {
            existingSlimes.Remove(slime);

            if (existingSlimes.Count < minimumNeededSlimes)
            {
                GameManager.Instance.OnGameLost?.Invoke();
            }
        }
    }
}
