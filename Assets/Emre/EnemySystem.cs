using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType { Regular, Timed }
    public EnemyType enemyType;

    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public float attackRate = 1f;
    public int damage = 1;
    public float followDistance = 5f;
    public float destroyDelay = 3f; // Belirli bir s�re sonra yok olma s�resi
    private float followStartTime; // Takip etmeye ba�lama zaman�
    private bool isFollowingPlayer = false;
    private float nextAttackTime = 0f;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public GameObject deathParticle; // �lme partik�l efekti

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Oyuncuya yakla�
            if (!isFollowingPlayer && Vector2.Distance(transform.position, player.position) < followDistance)
            {
                isFollowingPlayer = true;
                followStartTime = Time.time; // Takip etmeye ba�lama zaman�n� ayarla
            }

            if (isFollowingPlayer)
            {
                Vector2 targetPosition = new Vector2(player.position.x, player.position.y);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                // Oyuncuya yak�nsa sald�r
                float distanceToPlayer = Vector2.Distance(transform.position, player.position);
                if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }

                // Belirli bir s�re sonra yok ol
                if (enemyType == EnemyType.Timed && Time.time >= followStartTime + destroyDelay)
                {
                    Die();
                }
            }
        }
    }

    void Attack()
    {
        Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        foreach (Collider2D player in playersToDamage)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    void Die()
    {
        if (deathParticle != null)
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity); // Partik�l efekti olu�tur
        }
        Destroy(gameObject); // D��man� yok et
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector2 attackPosition = (Vector2)transform.position + (Vector2)transform.right * attackRange;

        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }

}
