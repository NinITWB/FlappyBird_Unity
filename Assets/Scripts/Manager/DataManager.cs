using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private int currentScore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("FirstPlayed"))
        {
            currentScore = GameManager.Instance.score;
            PlayerPrefs.SetInt("BestScore", currentScore);
            PlayerPrefs.SetInt("FirstPlayed", 0);
        }
    }

    public void UpdateBestScore(TextMeshProUGUI bestScore)
    {
        currentScore = GameManager.Instance.score;
        if (currentScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

}
