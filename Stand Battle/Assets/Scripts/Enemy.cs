using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 3f;
    public float stopDistance = 1f;

    void Update()
    {


        // Direction toward player
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Distance to player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Move toward player if farther than stop distance
        if (distance > stopDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
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