using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private string spawnPoint;

    public void LevelLoad(string levelName, string spawnPoint)
    {
        SaveSystem.LoadScene(levelName + "@" + spawnPoint);
    }
}
    
