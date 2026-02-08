using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfCoins;
    public TMP_Text coinsText;
    public TMP_Text levelText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    void Update()
    {   
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins: " + numberOfCoins;
        levelText.text = "Level: " + LevelManager.selectedLevel;
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            startingText.SetActive(false);
        }
        
    }
}
