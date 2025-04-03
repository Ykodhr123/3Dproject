using TMPro;
using UnityEngine;

public class finish : MonoBehaviour
{

    public GameObject fireworks;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI warningText;
    public int requiredCoins = 700;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.coinCount >= requiredCoins)
            {
                // Success
                if (fireworks != null)
                    fireworks.SetActive(true);

                if (winText != null)
                    winText.gameObject.SetActive(true);

                if (warningText != null)
                    warningText.gameObject.SetActive(false);

                Debug.Log("Player wins!");
            }
            else
            {
                // Not enough coins
                if (warningText != null)
                {
                    warningText.text = "You need 700 coins to win!";
                    warningText.gameObject.SetActive(true);
                }

                Debug.Log("Not enough coins.");
            }
        }
    }
}