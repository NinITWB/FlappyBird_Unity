using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BirdMove : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] Button button;

    private bool isClick;

    public bool isOvercome { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(IsClick);
        if (isClick )
        {
            Movement();
        }
    }

    private void IsClick()
    {
        isClick = true;
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * thrust * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deadzone"))
        {
            gameObject.SetActive(false);
            UIStart.instance.LoadScene();
        }
    }
}
