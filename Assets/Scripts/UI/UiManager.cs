using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    SoundManager soundManager;
    LevelManager levelManager;
    GameManager gameManager;
    private void Start()
    {
        soundManager = SoundManager.instance;
        if (soundManager == null)
        {
            Debug.LogError("Sm not found");
        }
        levelManager = LevelManager.instance;
        if (levelManager == null)
        {
            Debug.LogError("Lm not found");
        }
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("Gm not found");
        }

    }
    public void LoadLevel(int buildIndex)
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
            if (gameManager)
            {
                gameManager.LoadLevel(buildIndex);
                soundManager.ResetSounds();
            }
        }
    }

    public void LoadNextLevel()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
            if (gameManager)
            {
                soundManager.ResetSounds();
                gameManager.LoadNextLevel();
            }
        }
    }

    public void Quit()
    {
        if (soundManager) soundManager.PlaySfx(Sounds.ButtonClick);
        Application.Quit();
    }

    public void ReStart()
    {
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.ButtonClick);
            if (gameManager)
            {
                gameManager.Restart();
                soundManager.ResetSounds();
            }
        }
    }
}
