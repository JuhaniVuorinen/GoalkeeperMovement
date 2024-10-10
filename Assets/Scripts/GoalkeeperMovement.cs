using UnityEngine;

public class GoalkeeperMovement : MonoBehaviour
{
    public Transform puck; // Reference to the puck
    public float speed = 5f; // Speed of the goalkeeper's movement
    public float minX = -5f;
    public float maxX = 5f;

    void Update()
    {
        float targetX = puck.position.x;
        targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            
    }
}
