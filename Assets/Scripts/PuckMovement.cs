using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the puck's movement
    private Vector3 direction; // Direction of puck movement
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetInitialDirection();
    }

    void Update()
    {
        rb.velocity = direction * speed;

        if (transform.position.y > 5)
        {
            transform.position = new Vector3(Random.Range(-4.5f, 4.5f), -5, 0);
        }

        Debug.Log("Puck is moving: " + transform.position);
    }

    private void SetInitialDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        direction = new Vector3(randomX, 1, 0).normalized; // Moving upwards
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Goalkeeper"))
        {
            Vector3 puckPosition = transform.position;
            Vector3 goaliePosition = collision.transform.position;

            float offset = puckPosition.x - goaliePosition.x;

            if (offset < 0)
            {
                direction = GetRandomBounceDirection(-1, -1);
            }
            else if (offset > 0)
            {
                direction = GetRandomBounceDirection(1, -1);
            }
            else
            {
                direction.y = -1; // Keep moving straight down
            }

            direction.Normalize();
            Vector3 pushBack = direction * 0.1f;
            rb.position += pushBack;

            Debug.Log("Puck hit the goalkeeper! New direction: " + direction);
        }
        else if (collision.gameObject.CompareTag("Boundary")) // For left and right boundaries
        {
            direction.x = -direction.x; // Reverse puck direction horizontally
            Debug.Log("Puck hit a side boundary!");
        }
        else if (collision.gameObject.CompareTag("BottomBoundary"))
        {
            direction = GetRandomBounceDirection(Random.Range(-1f, 1f), 1); // Bounce up at a random angle
            Debug.Log("Puck hit the bottom boundary! New direction: " + direction);
        }
    }

    private Vector3 GetRandomBounceDirection(float baseX, float baseY)
    {
        float randomOffsetX = Random.Range(-0.5f, 0.5f); // Random horizontal offset
        return new Vector3(baseX + randomOffsetX, baseY, 0).normalized;
    }
}
