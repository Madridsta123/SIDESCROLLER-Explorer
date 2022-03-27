using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 normalPos;
    float xOffset;
    float yOffset;

    private void Start()
    {
        normalPos = transform.position;
        xOffset = transform.position.x - player.position.x;
        yOffset = transform.position.y - player.position.y;

    }
    private void Update()
    {
        Vector3 pos = player.position;
        if (transform.position.y > normalPos.y - 5)
        {
            transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
        }
    }
}
