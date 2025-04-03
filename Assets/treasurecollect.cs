using UnityEngine;

public class treasurecollect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int minCoinValue = 50;
    public int maxCoinValue = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomCoins = Random.Range(minCoinValue, maxCoinValue + 1); // +1 to include 100
            GameManager.instance.AddCoin(randomCoins);

            Debug.Log("Player collected " + randomCoins + " coins!");
            Destroy(gameObject);
        }
    }
}