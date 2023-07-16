using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    
    public bool isCollide { get; private set; }
    [SerializeField] private LayerMask backGroundLayer;

    private void Awake()
    {
        isCollide = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("pipe"))
        {
            GameManager.Instance.EndGame();
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }


        int colLayerInBitmask = 1 << collision.gameObject.layer;

        if (colLayerInBitmask == backGroundLayer.value)
        {
            GameManager.Instance.EndGame();
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
