using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public void ChooseSlime()
    {
        SetChosenCharacter("Slime");
    }

    public void ChooseMetalSlime()
    {
        SetChosenCharacter("MetalSlime");
    }
    public void ChooseRandomSlime()
    {
        // Randomly choose between "Slime" and "MetalSlime"
        int randomIndex = Random.Range(0, 2);
        string randomCharacter = (randomIndex == 0) ? "Slime" : "MetalSlime";

        SetChosenCharacter(randomCharacter);
    }
    private void SetChosenCharacter(string character)
    {
        PlayerPrefs.SetString("PlayerOption", character);
        PlayerPrefs.Save();

        Debug.Log("Chosen Character: " + character);
    }
}
