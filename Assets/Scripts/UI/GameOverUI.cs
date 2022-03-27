using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //Game-Over
    [SerializeField] GameObject guiCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject bloodPS;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void GameOver()
    {
        Instantiate(bloodPS,transform);
        SoundManager soundManager = SoundManager.instance;
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.Death);
            soundManager.StopMusic();
        }
        gameOverCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
