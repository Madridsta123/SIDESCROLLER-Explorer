using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
