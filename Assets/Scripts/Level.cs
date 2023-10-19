using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int Experience = 0;

    public void AddExperience(int givenXP)
    {
        Experience += givenXP;

        // Check the experience against thresholds using a switch statement
        switch (Experience)
        {
            case 5:
                Debug.Log("Reached 5 XP!");
                break;
            case 10:
                Debug.Log("Reached 10 XP!");
                break;
            case 20:
                Debug.Log("Reached 20 XP!");
                break;
            case 40:
                Debug.Log("Reached 40 XP!");
                break;
            case 70:
                Debug.Log("Reached 70 XP!");
                break;
            case 100:
                Debug.Log("Reached 100 XP!");
                break;
            case 120:
                Debug.Log("Reached 120 XP!");
                break;
            case 150:
                Debug.Log("Reached 150 XP!");
                break;
        }
    }
}
