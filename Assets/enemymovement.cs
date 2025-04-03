using UnityEngine;


public class enemymovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }
}