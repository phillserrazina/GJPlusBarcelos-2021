using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime.Utilities
{
    public class SceneTransitionHelper : MonoBehaviour
    {
        public void LoadSceneAsync(string sceneName)
        {
            SceneLoader.Instance.LoadSceneAsync(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
