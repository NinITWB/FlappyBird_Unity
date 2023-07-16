using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private float speed;
    //private bool isOver;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsGameOver)
            {
                return;
            }
        }
        Movement();
    }

    private void Movement()
    {
        speed = GameManager.Instance.PipeSpeed;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    
    
}
