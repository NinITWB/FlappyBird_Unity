using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartButton : MonoBehaviour
{

    public void StartOnClick()
    {
        Time.timeScale = 1;
        UiManager.Instance.OffTutorialPanel();
    }
}
