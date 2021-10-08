using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Slime.Utilities
{
    public class SceneLoader : MonoBehaviour {
        
        // VARIABLES
        public static SceneLoader Instance { get; private set; }

        [SerializeField] private float minTransitionTime = 2.0f;
        [SerializeField] private GameObject loadingObject = null;
        private Animator loadingAnimator;
        private bool isLoading = false;
        private float timeElapsed = 0.0f;

        public Scene CurrentScene { get { return SceneManager.GetActiveScene(); } }

        // EXECUTION FUNCTIONS

        private void Awake() 
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start() {
            loadingObject.SetActive(false);
            loadingAnimator = loadingObject.GetComponent<Animator>();
            DontDestroyOnLoad(loadingObject.gameObject);
        }

        // METHODS

        public void LoadSceneInstant(string sceneName) => SceneManager.LoadScene(sceneName);

        public void LoadSceneAsync(string sceneName) 
        {
            if (!isLoading) 
            {
                Time.timeScale = 1f;
                StartCoroutine(LoadAsyncScene(sceneName));
            }
        }

        private IEnumerator LoadAsyncScene(string scene) 
        {
            isLoading = true;
            timeElapsed = 0;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
            asyncLoad.allowSceneActivation = false;

            loadingObject.SetActive(true);
            loadingAnimator.speed = 1 / minTransitionTime;
            loadingAnimator.Play("LoadingFadeIn");

            while (!asyncLoad.isDone) {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= minTransitionTime)
                    asyncLoad.allowSceneActivation = true;
                
                yield return null;
            }

            isLoading = false;

            loadingAnimator.Play("LoadingFadeOut");
            loadingAnimator.speed = 1 / minTransitionTime;
            yield return new WaitForSecondsRealtime(minTransitionTime);
            loadingObject.SetActive(false);
        }
    }
}

