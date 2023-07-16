using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    public static UIStart instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
