using UnityEngine;

public class GoalkeeperMovement : MonoBehaviour
{
    public Transform puck; // Reference to the puck
    public float speed = 5f; // Speed of the goalkeeper's movement

    void Update()
    {
        if (puck != null)
        {
            // Move the goalkeeper towards the puck's x-position
            Vector3 targetPosition = new Vector3(puck.position.x, transform.position.y, transform.position.z);

            // Move the goalkeeper horizontally only
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
