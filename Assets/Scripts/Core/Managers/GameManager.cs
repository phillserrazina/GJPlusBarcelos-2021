using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime.UI;

namespace Slime.Core
{
    public class GameManager : MonoBehaviour
    {
        // VARIABLES
        public static GameManager Instance { get; private set; }

        public bool IsPlaying { get; private set; } = true;

        public delegate void OnGamePausedDelegate(bool value);
        public OnGamePausedDelegate OnGamePaused;

        public delegate void OnGameWonDelegate();
        public OnGameWonDelegate OnGameWon;

        public delegate void OnGameLostDelegate();
        public OnGameLostDelegate OnGameLost;

        public bool IsPaused { get; private set; }

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            Instance = this;
            OnGameWon += () => { IsPlaying = false; };
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }    
        }

        // METHODS
        public void SetGameActive(bool value) => IsPlaying = value;

        public void WinWithDelay(float delay)
        {
            OnGameWon?.Invoke();

            Invoke(nameof(StopGame), delay);
        }

        private void StopGame()
        {
            IsPlaying = false;
        }

        public void PauseGame()
        {
            IsPaused = !IsPaused;

            Time.timeScale = IsPaused ? 0 : 1;
            OnGamePaused?.Invoke(IsPaused);
        }
    }
}
