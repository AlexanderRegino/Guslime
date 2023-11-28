using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] TextMeshProUGUI highScoreText;
    private void Awake()
    {
        UpdateHighScoreText();
    }

    public void setHighScore(int coinTotal)
    {

        highScoreText.text = $"Coins: {coinTotal}";
        
    }
    void UpdateHighScoreText()
    {
      highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
