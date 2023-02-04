using Game.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Game.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private GameObject gameOverPanel;
        private void Awake()
        {
            SetupInstance();
        }
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadSceneByBuildIndex()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoseGame()
        {
            if (gameOverPanel == null) return;
            StartCoroutine(ReturnToMainMenu());
        }

        private IEnumerator ReturnToMainMenu()
        {
            gameOverPanel.SetActive(true);
            yield return new WaitForSeconds(3);
            this.LoadSceneByIndex(0);
        }
    }
}
