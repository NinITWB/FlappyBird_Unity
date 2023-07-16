using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
    [SerializeField] private float forceJump;
    [SerializeField] private float jumpAngle;
    [SerializeField] private float rotateAngle;
    public bool isDead { get; private set; }
    private PlayerInput input;
    private InputAction action;

    private Rigidbody2D rigid;
    private bool isJump;
    private bool isStart;
    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        isDead = false;

        action = input.actions["fly control"];
        
        action.performed += Action_performed;
        StartCoroutine(StartTime());
        
    }



    // Update is called once per frame
    private void Update()
    {
        if (!isStart)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.IsGameOver)
                {
                    return;
                }
            }
            RotateBack();
        }
       
    }

    

    private void Action_performed(InputAction.CallbackContext obj)
    {
        isJump = true;
    }

    private IEnumerator StartTime()
    {
        isStart = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSecondsRealtime(1.5f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        isStart = false;
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.IsGameOver)
                {
                    return;
                }
            }

            if (isJump)
            {
                jump();
                isJump = false;
            }
        }
        
            
    }

    private void RotateBack()
    {
        Quaternion first = transform.rotation;
        Quaternion second = Quaternion.Euler(0, 0, -30);
        transform.rotation = Quaternion.Lerp(first, second, 2 * Time.deltaTime);
    }

    private void jump()
    {
        rigid.velocity = Vector2.up * forceJump * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, jumpAngle);
    }
}
