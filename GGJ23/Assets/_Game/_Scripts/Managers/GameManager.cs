using Game.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Game.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
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
            // game over ekranı aktif olacak
            // 3 saniye geçtikten sonra main menüye atsın
            //Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!");
            //StartCoroutine(ReturnToMainMenu());
            this.LoadSceneByIndex(0);
        }

        public void Quit() 
        {
            Application.Quit();
        }

        private IEnumerator ReturnToMainMenu()
        {
            yield return new WaitForSeconds(3);
            this.LoadSceneByIndex(0);
        }



    }
}
