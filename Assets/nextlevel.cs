using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class nextlevel : MonoBehaviour
{
    
    public string sceneToLoad = "Level2";
    public int requiredCoins = 500;
    public GameManager gameManager;
    public TMP_Text warningText; // TMP version!

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.coinCount >= requiredCoins)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                if (warningText != null)
                {
                    warningText.text = "You need 500 coins to proceed!";
                    warningText.gameObject.SetActive(true);
                    Invoke("HideWarning", 2f);
                }
            }
        }
    }

    void HideWarning()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
}