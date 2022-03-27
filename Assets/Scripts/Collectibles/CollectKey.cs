using UnityEngine;

public class CollectKey : MonoBehaviour
{
    bool canAddScore;
    Animator animator;
    private void Start()
    {
        canAddScore = true;
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canAddScore && collision.gameObject.tag == "Player")
        {    
             canAddScore = false;
             animator.Play("Collected");
             ScoreControler scoreController = collision.gameObject.GetComponent<ScoreControler>();
             scoreController.increaseScore();
             Invoke("DestroyKey", .6f); 
        }
    }

    void DestroyKey()
    {
        Destroy(gameObject);
    }
}
