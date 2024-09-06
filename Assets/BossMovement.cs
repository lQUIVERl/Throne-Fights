using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f; // Boss'un hareket hýzý
    [SerializeField] float stoppingDistance = 3f; // Oyuncuya ne kadar yaklaþtýðýnda duracak
    [SerializeField] float detectionRange = 10f; // Oyuncunun algýlanma mesafesi
    [SerializeField] Transform player; // Player objesi
    [SerializeField] GameObject projectilePrefab; // Fýrlatýlacak mermi
    [SerializeField] Transform firePoint; // Merminin çýkacaðý yer
    [SerializeField] float projectileSpeed = 5f; // Merminin hýzý
    [SerializeField] float projectileCooldown = 3f; // Mermi atýþ süresi
    Animator animator;
    bool isActivated = false; // Boss'un aktif olup olmadýðýný kontrol eder
    bool isDead = false; // Boss öldüðünde true olur
    bool canAttack = true; // Mermi atýþý için cooldown
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead) return; // Eðer boss öldüyse hareket etmesin

        // Oyuncu belirli bir mesafeye geldiyse boss hareket etmeye baþlasýn
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isActivated && distanceToPlayer <= detectionRange)
        {
            isActivated = true; // Boss'u aktifleþtir
        }

        if (isActivated)
        {
            if (distanceToPlayer > stoppingDistance)
            {
                // Hareket etme
                animator.SetBool("isMoving", true);
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // Boss'un yönünü player'a çevirme
                if (player.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true; // Eðer player soldaysa sola bak
                }
                else
                {
                    spriteRenderer.flipX = false; // Eðer player saðdaysa saða bak
                }
            }
            else
            {
                // Oyuncuya yaklaþtýðýnda dur ve saldýr
                animator.SetBool("isMoving", false);

                if (canAttack)
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        // Projectile atýþý
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Vector2 targetDirection = (player.position - firePoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = targetDirection * projectileSpeed;

        Destroy(projectile, 2f); // Mermi 2 saniye sonra yok olacak

        yield return new WaitForSeconds(projectileCooldown); // Atýþtan sonra bekleme süresi
        canAttack = true;
    }

    public void TakeDamage(int damage)
    {
        // Boss'a zarar gelirse hayatýný düþür ve ölme animasyonunu oynat
        GetComponent<Health>().TakeDamage(damage);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetTrigger("Die"); // Ölme animasyonunu tetikle
            StartCoroutine(WaitForDeathAnimation()); // Animasyonun bitmesini bekle
        }
    }

    IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(2f); // 2 saniye boyunca animasyonun oynatýlmasýný bekle
        Destroy(gameObject); // Boss'u yok et
    }
}
