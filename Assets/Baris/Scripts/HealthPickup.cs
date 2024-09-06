using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            if (playerHealth != null && playerHealth.CurrentHealt < playerHealth.MaxHealt)
            {
                playerHealth.CurrentHealt += healthAmount; 

                if (playerHealth.CurrentHealt > playerHealth.MaxHealt)
                {
                    playerHealth.CurrentHealt = playerHealth.MaxHealt;
                }

                Destroy(gameObject); 
            }
        }
    }
}
