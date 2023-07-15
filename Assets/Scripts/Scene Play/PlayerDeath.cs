using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    
    public bool isCollide { get; private set; }

    private void Awake()
    {
        isCollide = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("pipe"))
        {

            GameManager.Instance.EndGame();
        }
    }
}
