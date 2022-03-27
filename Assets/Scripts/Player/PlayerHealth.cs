
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] GameOverUI gameOverScript;

    int heartCount;

    Animator animator;

    private void Start()
    {
        heartCount = hearts.Length;
        animator = GetComponent<Animator>();
    }
    public void damagePlayer()
    {
        if (heartCount > 1)
        {
            hearts[heartCount - 1].color = Color.white;
            heartCount--;
            animator.Play("PlayerHurt");
            animator.SetTrigger("Hurt");
        }
        else
        {
            KillPlayer();

        }      
    }
    public void KillPlayer()
    {
        animator.Play("PlayerDeath");
        Invoke("LoadGameOver", .5f);

    }
    void LoadGameOver()
    {
        gameOverScript.GameOver();
    }
}
