using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        
        public void Play()
        {
            SceneManager.LoadScene("Scenes/GameScene");
        }

        public void Play960()
        {
            SceneManager.LoadScene("Scenes/960Scene");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Settings()
        {
            
        }
    }
}
