using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool isGameOver = false;
    private int mark = 0;
    [SerializeField] private float pipeSpeed;
    public float timeRecover { get; set; }
    public float score { get; set; }

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

    private void Update()
    {
        UpgradeSpeedAndTime();
    }

    public bool UpgradeCondition()
    {
        if (this.score >= 2 && mark == 0) 
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
        if (UpgradeCondition())
        {
            this.pipeSpeed *= 1.2f;
            this.timeRecover -= .5f;
        }
    }    

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
        UiManager.Instance.UIAfterDeath();
    }

}
