using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    LevelManager levelManager;

    private void Awake()
    {
        if (_instance)
        {
            Destroy(this);

        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        levelManager = LevelManager.instance;
        if(! levelManager)
        {
            Debug.LogError("Levelmanager not found");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        LevelStatus levelStat = (LevelStatus)PlayerPrefs.GetInt(levelManager.levelNames[buildIndex]);

        if (levelStat == LevelStatus.Unlocked || levelStat==LevelStatus.Completed)
        {
            SceneManager.LoadScene(buildIndex);
        }
        else Debug.Log("Not unlocked"+levelStat);
    }
    public void LoadNextLevel()
    {
        int targetBuildIndex = SceneManager.GetActiveScene().buildIndex+1;

        LevelStatus levelStat = (LevelStatus) PlayerPrefs.GetInt(levelManager.levelNames[targetBuildIndex]);

        if ( levelStat== LevelStatus.Unlocked || levelStat== LevelStatus.Completed)     SceneManager.LoadScene(targetBuildIndex);

        else Debug.Log("Not unlocked"+levelStat);
    }
}

