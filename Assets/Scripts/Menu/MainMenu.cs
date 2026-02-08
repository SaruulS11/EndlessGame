using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject difficulty;
    public int level;

    public void Play()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        difficulty.SetActive(true);
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PlayLevel(int levelIndex)
    {
        LevelManager.SelectLevel(levelIndex);
        level = levelIndex;
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Quit");
    }
}
