using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 3;  // Enemy health value

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage! Remaining Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " is defeated!");
        Destroy(gameObject);  // Remove the crawler from the game
    }
}