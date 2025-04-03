using UnityEngine;
using System.Collections;
public class WeaponController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float attackRange = 2f;        // Range of weapon attack
    public int damage = 1;                // Damage per hit
    public LayerMask enemyLayer;          // Layer to detect enemies
    public float attackRate = 1f;         // Time between attacks
    private float nextAttackTime = 0f;    // Cooldown for next attack

    public GameObject hitEffectPrefab;    // Optional hit effect

    void Update()
    {
        // Check if the player clicks Left Mouse Button (0) or presses E
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;  // Attack cooldown
            }
        }
    }

    void Attack()
    {
        IEnumerator SwingWeapon()
        {
            // Swing the weapon down and back up
            float duration = 0.3f;  // Increased duration for a longer swing

            // Get the original rotation of the weapon
            Quaternion originalRotation = transform.localRotation;
            Quaternion downRotation = originalRotation * Quaternion.Euler(45f, 0f, 0f);  // Swing down further

            // Swing down
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                transform.localRotation = Quaternion.Lerp(originalRotation, downRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Swing back up
            elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                transform.localRotation = Quaternion.Lerp(downRotation, originalRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.localRotation = originalRotation;  // Reset after swing
        }
        Debug.Log("Player attacked!");
        StartCoroutine(SwingWeapon());

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Check for both enemy types
            Enemyhealth crawler = hit.collider.GetComponentInParent<Enemyhealth>();
            Zombiehealth zombie = hit.collider.GetComponentInParent<Zombiehealth>();

            if (crawler != null)
            {
                crawler.TakeDamage(damage);
            }
            else if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            else
            {
                Debug.Log("No valid enemy script found!");
            }

            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
    // Draw the attack range in the Scene view for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * attackRange);
    }
}