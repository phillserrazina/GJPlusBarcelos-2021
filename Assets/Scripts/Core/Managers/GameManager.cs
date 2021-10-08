using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // VARIABLES
    public static GameManager Instance { get; private set; }

    public bool IsPlaying { get; private set; } = true;

    public delegate void OnGameWonDelegate();
    public OnGameWonDelegate OnGameWon;

    public delegate void OnGameLostDelegate();
    public OnGameLostDelegate OnGameLost;

    // EXECUTION FUNCTIONS
    private void Awake()
    {
        Instance = this;
        OnGameWon += () => { IsPlaying = false; };
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
}
