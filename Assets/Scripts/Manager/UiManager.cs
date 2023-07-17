using System;
using System.Collections;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI bestScore;
    

    [SerializeField] private Sprite[] medals;
    private int scoreLevel;

    private void OnEnable()
    {
        StartCoroutine(ShowGameStartTitle());
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
        //finalScore.enabled = false;    

    }

    public TMP_Text TextMeshPro
    {
        get { return _textMeshPro; }
        set { _textMeshPro = value; }
    }

    public void UIAfterDeath()
    {
        scoreLevel = Convert.ToInt32(_textMeshPro.text);
        MedalRule(scoreLevel);
        _textMeshPro.enabled = false;
        gameOver.SetActive(true);
        endingBoard.SetActive(true);
        StartCoroutine(CountScore(scoreLevel, 1.8f));
        DataManager.instance.UpdateBestScore(bestScore);
        medal.enabled = true;
    }

    private IEnumerator CountScore(int score, float duration)
    {
        finalScore.text = 0.ToString();
       

        if (score != 0)
        {
            float yieldTime = duration / score;
            for (int i = 1; i <= score; i++)
            {
                finalScore.text = i.ToString();
                yield return new WaitForSeconds(yieldTime);
            }
        }
    }

    public void OffTutorialPanel()
    {
        tutorialPanel.SetActive(false);
    }

    public void PressPause()
    {
        GameManager.Instance.PauseGame();    
    }    

    private void MedalRule(int finalScore)
    {
        
        if (scoreLevel >= 0 && scoreLevel <= 7)
        {
            medal.sprite = medals[0];       //Set Bronze medal
        }
        else if (scoreLevel <= 20)
            medal.sprite = medals[1];       //Set Silver medal
        else
            medal.sprite = medals[2];       //Set Gold medal
    }

    public void ShowScore()
    {
        _textMeshPro.text = GameManager.Instance.score.ToString();
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ShowGameStartTitle()
    {
        title.SetActive(true);
        _textMeshPro.enabled = false;
        yield return new WaitForSecondsRealtime(1.5f);
        title.SetActive(false);
        tutorialPanel.SetActive(true);
        _textMeshPro.enabled = true;
        Time.timeScale = 0;
    }
}
