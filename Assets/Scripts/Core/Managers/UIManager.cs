using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    // EXECUTION FUNCTIONS
    private void Start() 
    {
        GameManager.Instance.OnGameWon += () => { winScreen.SetActive(true); };
        GameManager.Instance.OnGameLost += () => { loseScreen.SetActive(true); };
    }
}
