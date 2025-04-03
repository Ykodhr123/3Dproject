using UnityEngine;

public class zombiescript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Zombie touched the player!");
            GameManager.instance.playerHealth -= damage;
            GameManager.instance.UpdateUI();
        }
    }
}