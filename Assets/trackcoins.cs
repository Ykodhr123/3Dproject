using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int coinCount = 0;
    public int playerHealth = 10;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Automatically find UI in the new scene
        coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("HealthText")?.GetComponent<TextMeshProUGUI>();

        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 10);
        UpdateUI();

        if (playerHealth <= 0)
        {
            // Optional: Restart level, show game over, etc.
            Debug.Log("Player died!");
        }
    }

    public void UpdateUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;

        if (healthText != null)
            healthText.text = "Health: " + playerHealth + "/10";
    }
}