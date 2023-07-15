using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDisapearance : MonoBehaviour
{
    //[SerializeField] private Transform pipe;
    //[SerializeField] private LayerMask mask;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("deadzone"))
        {
            gameObject.SetActive(false);
        }

    }

    


}
