using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 20;
    private Vector2 targetPosition; // Player'ýn fýrlatýldýðý andaki pozisyonu

    private void Start()
    {
        // Player'ýn pozisyonunu al ve projectile o yöne doðru gitsin
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetPosition = player.transform.position;
        }

        // 2 saniye sonra projectile yok edilsin
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        // Eðer hedef pozisyon belirlendiyse, oraya doðru hareket et
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer projectile, Player'a çarparsa zarar versin
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Çarptýðýnda yok olsun
        }
        else if (collision.CompareTag("Wall"))
        {
            // Duvara çarparsa yok et
            Destroy(gameObject);
        }
    }
}
