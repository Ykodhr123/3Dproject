using UnityEngine;

public class Zombiehealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Zombie took damage! Current HP: " + health);
        if (health <= 0)
        {
            Debug.Log("Zombie died!");
            Destroy(transform.root.gameObject);
        }
    }
}