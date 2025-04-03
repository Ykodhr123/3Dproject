using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth = 10;  // New value - Increased to 10
    private int currentHealth;        // Current health
    public TextMeshProUGUI healthText;  // TextMeshProUGUI for TMP text
    public string levelToRestart = "SampleScene";  // Name of the scene to restart

    void Start()
    {
        currentHealth = maxHealth;  // Set to full health at start
        UpdateHealthUI();  // Optional - if using UI
    }

    // Called when player collides with crawler
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))  // Crawler or enemy should have "Enemy" tag
        {
            TakeDamage(1);  // Reduce health by 1
        }
    }

    // Reduce health and check if player dies
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took " + amount + " damage. Health: " + currentHealth);

        UpdateHealthUI();  // Optional if you're displaying health on UI

        if (currentHealth <= 0)
        {
            Die();  // Restart or trigger death if health reaches 0
        }
    }

    // Update the UI Text with current health
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    // Restart the level when health reaches 0
    void Die()
    {
        Debug.Log("Player died! Restarting...");
        SceneManager.LoadScene(levelToRestart);
    }
}