using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f; // Boss'un hareket h�z�
    [SerializeField] float stoppingDistance = 3f; // Oyuncuya ne kadar yakla�t���nda duracak
    [SerializeField] float detectionRange = 10f; // Oyuncunun alg�lanma mesafesi
    [SerializeField] Transform player; // Player objesi
    [SerializeField] GameObject projectilePrefab; // F�rlat�lacak mermi
    [SerializeField] Transform firePoint; // Merminin ��kaca�� yer
    [SerializeField] float projectileSpeed = 5f; // Merminin h�z�
    [SerializeField] float projectileCooldown = 3f; // Mermi at�� s�resi
    Animator animator;
    bool isActivated = false; // Boss'un aktif olup olmad���n� kontrol eder
    bool isDead = false; // Boss �ld���nde true olur
    bool canAttack = true; // Mermi at��� i�in cooldown
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead) return; // E�er boss �ld�yse hareket etmesin

        // Oyuncu belirli bir mesafeye geldiyse boss hareket etmeye ba�las�n
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isActivated && distanceToPlayer <= detectionRange)
        {
            isActivated = true; // Boss'u aktifle�tir
        }

        if (isActivated)
        {
            if (distanceToPlayer > stoppingDistance)
            {
                // Hareket etme
                animator.SetBool("isMoving", true);
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

                // Boss'un y�n�n� player'a �evirme
                if (player.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true; // E�er player soldaysa sola bak
                }
                else
                {
                    spriteRenderer.flipX = false; // E�er player sa�daysa sa�a bak
                }
            }
            else
            {
                // Oyuncuya yakla�t���nda dur ve sald�r
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
        // Projectile at���
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Vector2 targetDirection = (player.position - firePoint.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = targetDirection * projectileSpeed;

        Destroy(projectile, 2f); // Mermi 2 saniye sonra yok olacak

        yield return new WaitForSeconds(projectileCooldown); // At��tan sonra bekleme s�resi
        canAttack = true;
    }

    public void TakeDamage(int damage)
    {
        // Boss'a zarar gelirse hayat�n� d���r ve �lme animasyonunu oynat
        GetComponent<Health>().TakeDamage(damage);
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetTrigger("Die"); // �lme animasyonunu tetikle
            StartCoroutine(WaitForDeathAnimation()); // Animasyonun bitmesini bekle
        }
    }

    IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(2f); // 2 saniye boyunca animasyonun oynat�lmas�n� bekle
        Destroy(gameObject); // Boss'u yok et
    }
}
