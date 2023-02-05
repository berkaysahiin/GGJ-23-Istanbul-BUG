using System;
using Game.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Game.Controllers;
using Game.Enemy;
using Game.UIs;

namespace Game.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private OxygenController _oxygenController;

        private bool _gameOver;
        public bool GameOver => _gameOver;
        private void Awake()
        {
            SetupInstance();

            Debug.Log("BUILD INDEX: " + SceneManager.GetActiveScene().buildIndex);

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                _oxygenController = FindObjectOfType<OxygenController>();
                Debug.Log("AA:" + _oxygenController);
            }
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
            _gameOver = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoseGame()
        {
            StartCoroutine(ReturnToMainMenu());
        }


        private IEnumerator ReturnToMainMenu()
        {
            yield return new WaitForSeconds(3.0f);
            CardManager.Instance.ClearList();
            OxygenController.Instance.ResetOxygenAmount();
            LevelManager.Instance.ResetDayCount();
            this.LoadSceneByIndex(0);
        }
    }
}
