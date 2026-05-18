using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody playerRb;

    // Camera limits
    private float leftLimit;
    private float rightLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        // Get camera screen edges
        float screenHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        leftLimit = Camera.main.transform.position.x - screenHalfWidth;
        rightLimit = Camera.main.transform.position.x + screenHalfWidth;
    }

    void Update()
    {
        MovePlayer();
        KeepPlayerInView();
    }

    void MovePlayer()
    {
        // Left and right movement
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, playerRb.linearVelocity.y, 0);

        playerRb.linearVelocity = movement;
    }

    void KeepPlayerInView()
    {
        // Keep player inside camera view
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);

        transform.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if collided object has tag "Stand"
        if (other.CompareTag("Stand"))
        {
            Destroy(gameObject);
        }
    }



}