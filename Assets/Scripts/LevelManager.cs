using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int selectedLevel = 0;
    public static bool levelSelected = false;
    

    public static void SelectLevel(int levelIndex)
    {
        selectedLevel = levelIndex;
        levelSelected = true;
    }
}
