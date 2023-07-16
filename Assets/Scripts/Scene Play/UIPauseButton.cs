using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseButton : MonoBehaviour
{
    [SerializeField] private Image pauseButton;
    [SerializeField] private Sprite resume;

    private Sprite pause;
    // Start is called before the first frame update
    private void Start()
    {
        pause = pauseButton.sprite;
    }

    public void PauseOnClick()
    {
        ChangeSprite();
        UiManager.Instance.PressPause();
    }

    private void ChangeSprite()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.isPauseGame)
            {
                pauseButton.sprite = pause;
            }
            else
            {
                pauseButton.sprite = resume;
            }
        }
    }

    
}
