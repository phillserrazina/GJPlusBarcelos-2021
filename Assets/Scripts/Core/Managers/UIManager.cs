using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime.Core;

namespace Slime.UI
{
    public class UIManager : MonoBehaviour
    {
        // EXECUTION FUNCTIONS
        private void Start() 
        {
            GameManager.Instance.OnGameWon += () => { MenuManager.Instance.SetMenuActive("Win Menu"); };
            GameManager.Instance.OnGameLost += () => { MenuManager.Instance.SetMenuActive("Lose Menu"); };
            GameManager.Instance.OnGamePaused += isPaused => { MenuManager.Instance.SetMenuActive(isPaused ? "Pause Menu" : null); };
        }
    }
}
