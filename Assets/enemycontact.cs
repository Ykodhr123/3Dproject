using UnityEngine;
using UnityEngine.SceneManagement;


public class enemycontact : MonoBehaviour

{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger touched: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER HIT! Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}