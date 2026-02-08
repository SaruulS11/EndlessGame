using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public int currentLevel = 1;
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void NextLevel()
    {
        if(LevelManager.selectedLevel < 5)
        {
            LevelManager.selectedLevel += 1;
            SceneManager.LoadScene("Level");
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
