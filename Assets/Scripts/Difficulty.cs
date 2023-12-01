using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public void SetEasyDifficulty()
    {
        PlayerPrefs.SetString("DifficultyLevel", "Easy");
        PlayerPrefs.Save();
    }

    // Function to set difficulty to "Hard"
    public void SetHardDifficulty()
    {
        PlayerPrefs.SetString("DifficultyLevel", "Hard");
        PlayerPrefs.Save();
    }
}
