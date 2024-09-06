using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 20;
    private Vector2 targetPosition; // Player'�n f�rlat�ld��� andaki pozisyonu

    private void Start()
    {
        // Player'�n pozisyonunu al ve projectile o y�ne do�ru gitsin
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
        // E�er hedef pozisyon belirlendiyse, oraya do�ru hareket et
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er projectile, Player'a �arparsa zarar versin
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // �arpt���nda yok olsun
        }
        else if (collision.CompareTag("Wall"))
        {
            // Duvara �arparsa yok et
            Destroy(gameObject);
        }
    }
}
