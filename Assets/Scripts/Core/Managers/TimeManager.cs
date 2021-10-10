using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Slime.Core
{
    public class TimeManager : MonoBehaviour
    {
        // VARIABLES
        [SerializeField] private float time = 600;
        [SerializeField] private TextMeshProUGUI timerText;
        private float currentTime;

        // EXECUTION FUNCTIONS
        private void Awake() {
            currentTime = time;
        }

        private void Update() {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;

                var timeSpan = TimeSpan.FromSeconds(currentTime);

                timerText.text = timeSpan.ToString(@"mm\:ss");
                return;
            }

            timerText.text = "00:00";
            GameManager.Instance.OnGameLost?.Invoke();
        }
    }
}
