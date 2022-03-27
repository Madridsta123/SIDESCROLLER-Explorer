using UnityEngine;
using TMPro;

public class ScoreControler : MonoBehaviour
{
    int score ;
    [SerializeField] int scoreForKey;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
    }
    public void increaseScore()
    {
        SoundManager soundManager = SoundManager.instance;
        if (soundManager)
        {
            soundManager.PlaySfx(Sounds.KeyCollect);
        }
        score += scoreForKey;
        scoreText.text = "Score:" + score;
    }
  
}
