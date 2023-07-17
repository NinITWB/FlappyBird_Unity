using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;
    public static GameManager Instance;
    private bool isGameOver = false;
    private int mark = 0;
    public float timeRecover { get; set; }
    public int score { get; set; }

    public bool isPauseGame { get; private set; }

    public bool isUpgrade { get; private set; }

    public float PipeSpeed
    {
        get { return this.pipeSpeed; }
        set { this.pipeSpeed = value; }
    }

    public bool IsGameOver 
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    private void Awake()
    {
        Instance = this;
        timeRecover = 2.5f;
    }

    private void OnEnable()
    {
        mark = 0;
    }

    private void Start()
    {
        isPauseGame = false;
    }

    private void Update()
    {
        UpgradeSpeedAndTime();
    }

    public void PauseGame()
    {
        if (!isPauseGame)
        {
            Time.timeScale = 0;
            isPauseGame = true;
        }
        else
        {
            Time.timeScale = 1;
            isPauseGame = false;
        }
    }

    public bool UpgradeDifficulty()
    {
        if (this.score >= 10 && mark == 0) 
        {
            mark++;
            return true;
        }
        else if (this.score >= 30 && mark == 1)
        {
            mark++;
            return true;
        }

        return false;
    }
    
    

    private void UpgradeSpeedAndTime()
    {
        if (UpgradeDifficulty())
        {
            this.pipeSpeed *= 1.2f;
            this.timeRecover -= .5f;
        }
    }    

    public void EndGame()
    {
        isGameOver = true;
        UiManager.Instance.UIAfterDeath();
    }

}
