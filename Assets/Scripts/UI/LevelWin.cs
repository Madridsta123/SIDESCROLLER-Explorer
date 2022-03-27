using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelWin : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    SoundManager soundManager;
    LevelManager levelManager;

    private void Start()
    {
        winCanvas.SetActive(false);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winCanvas.SetActive(true);
            if (soundManager) soundManager.PlaySfx(Sounds.TelePortUse);
            collision.gameObject.SetActive(false);

            if (levelManager)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (PlayerPrefs.GetInt(levelManager.levelNames[scene.buildIndex]) != (int)LevelStatus.Completed)
                {
                    levelManager.SetLeveLStatus(scene.name, LevelStatus.Completed);
                }
                if (scene.buildIndex < levelManager.levelNames.Length - 1 && PlayerPrefs.GetInt(levelManager.levelNames[scene.buildIndex + 1]) != (int)LevelStatus.Unlocked)
                {
                    LevelManager.instance.SetLeveLStatus(levelManager.levelNames[scene.buildIndex + 1], LevelStatus.Unlocked);
                }
            }
        }
    }
}
