using UnityEngine;

public class ZOMBIEMOVEMENT : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed1 = 2f;

    void Update()
    {
        Vector3 moveDirection = transform.forward;  // Move along X-axis if facing right
        transform.position += moveDirection * moveSpeed1 * Time.deltaTime;
    }
}
