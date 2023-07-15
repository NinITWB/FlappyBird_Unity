using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    [SerializeField] private TMP_Text _textMeshPro;
    [SerializeField] private GameObject endingBoard;
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private Image medal;
    [SerializeField] private GameObject title;

    [SerializeField] private Sprite[] medals;

    public bool startGame { get; private set; }

    private int scoreLevel;

    private void OnEnable()
    {
        StartCoroutine(ShowGameTitle());
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }
        medal.enabled = false;
        finalScore.enabled = false;
    }

    public TMP_Text TextMeshPro
    {
        get { return _textMeshPro; }
        set { _textMeshPro = value; }
    }

    public void UIAfterDeath()
    {
        finalScore.text = _textMeshPro.text;
        scoreLevel = Convert.ToInt32(finalScore.text);
        MedalRule(scoreLevel);
        endingBoard.SetActive(true);
        finalScore.enabled = true;
        medal.enabled = true;
    }

    private void MedalRule(int finalScore)
    {
        if (scoreLevel >= 0 && scoreLevel <= 7)
        {
            medal.sprite = medals[0];
        }
        else if (scoreLevel <= 20)
            medal.sprite = medals[1];
        else
            medal.sprite = medals[2];
    }

    public void ShowScore()
    {
        _textMeshPro.text = GameManager.Instance.score.ToString();
    }

    private IEnumerator ShowGameTitle()
    {
        startGame = true;
        title.SetActive(true);
        _textMeshPro.enabled = false;
        yield return new WaitForSecondsRealtime(1.5f);
        startGame = false;
        title.SetActive(false);
        _textMeshPro.enabled = true;
    }
}
