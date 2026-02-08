using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject[] level1TilePrefabs;
    public GameObject[] level2TilePrefabs;
    public GameObject[] level3TilePrefabs;
    public GameObject[] level4TilePrefabs;
    public GameObject[] level5TilePrefabs;
    public GameObject[] currentLevel;
    public GameObject finisher;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    int levelIndex = LevelManager.selectedLevel;



    void Start()
    {
        if(LevelManager.selectedLevel == 1)
        {
            currentLevel = level1TilePrefabs;
        }else if(LevelManager.selectedLevel == 2)
        {
            currentLevel = level2TilePrefabs;
        }else if(LevelManager.selectedLevel == 3)
        {
            currentLevel = level3TilePrefabs;
        }else if(LevelManager.selectedLevel == 4)
        {
            currentLevel = level4TilePrefabs;
        }else if(LevelManager.selectedLevel == 5)
        {
            currentLevel = level5TilePrefabs;
        }
        for(int i=0; i<numberOfTiles; i++)
        {
            if(i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, currentLevel.Length));
        }
        SpawnFinisher();
    }

    void Update()
    {
        
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(currentLevel[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void SpawnFinisher()
    {
        GameObject go = Instantiate(finisher, transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        
        zSpawn += tileLength;
    }
}
