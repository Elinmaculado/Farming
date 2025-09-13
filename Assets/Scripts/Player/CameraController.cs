using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    
    public float zOffset = 7;
    public float smoothing = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z - zOffset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
