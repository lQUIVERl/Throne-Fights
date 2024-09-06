using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth = 300; // Boss'un toplam caný
    private int currentHealth;

    public GameObject player; // Oyuncu referansý
    public Transform[] attackPoints; // Saldýrý noktalarý

    public GameObject projectile; // Boss'un attýðý uzaktan saldýrý objesi
    public GameObject shield; // Boss’un kalkaný (eðer varsa)

    public float attackCooldown = 2f; // Saldýrýlar arasý bekleme süresi
    private float attackTimer = 0f;

    private int phase = 1; // Boss'un mevcut aþamasý

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta boss'un canýný en üst seviyeye ayarlýyoruz
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                AttackPlayer(); // Saldýrýyý gerçekleþtir
                attackTimer = 0f; // Zamanlayýcýyý sýfýrla
            }

            // Aþamalar arasýnda geçiþ
            CheckPhase();
        }
        else
        {
            Die(); // Boss öldü
        }
    }

    void AttackPlayer()
    {
        // Boss'un farklý saldýrýlar yapmasýný saðlayan bir saldýrý sistemi
        int randomAttack = Random.Range(0, 3); // 0: Yakýn saldýrý, 1: Uzak saldýrý, 2: Alan etkili saldýrý
        switch (randomAttack)
        {
            case 0:
                MeleeAttack();
                break;
            case 1:
                RangedAttack();
                break;
            case 2:
                AreaAttack();
                break;
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Boss yakýn saldýrý yapýyor!");
        // Boss oyuncuya doðru hamle yaparak yakýn saldýrý gerçekleþtirir
        // (Buraya boss'un oyuncuya doðru hýzla hareket ettiði bir kod eklenebilir)
    }

    void RangedAttack()
    {
        Debug.Log("Boss uzak saldýrý yapýyor!");
        // Uzak saldýrý için bir projectile fýrlatýyoruz
        foreach (Transform attackPoint in attackPoints)
        {
            Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        }
    }

    void AreaAttack()
    {
        Debug.Log("Boss alan saldýrýsý yapýyor!");
        // Yerden çýkan dikenler gibi bir alan saldýrýsý gerçekleþtirilebilir
    }

    void CheckPhase()
    {
        // Boss'un aþamalar arasýnda geçiþ yapmasýný saðlayan sistem
        if (currentHealth <= maxHealth * 0.75f && phase == 1)
        {
            EnterPhase2();
        }
        else if (currentHealth <= maxHealth * 0.5f && phase == 2)
        {
            EnterPhase3();
        }
        else if (currentHealth <= maxHealth * 0.25f && phase == 3)
        {
            EnterPhase4();
        }
    }

    void EnterPhase2()
    {
        phase = 2;
        Debug.Log("Boss 2. aþamaya geçti!");
        // 2. aþamaya geçtiðinde yeni saldýrýlar ekleyebiliriz
    }

    void EnterPhase3()
    {
        phase = 3;
        Debug.Log("Boss 3. aþamaya geçti!");
        // 3. aþamaya geçtiðinde savunma mekaniði ekleyebiliriz (örneðin kalkan)
        shield.SetActive(true); // Kalkan etkinleþtirilebilir
    }

    void EnterPhase4()
    {
        phase = 4;
        Debug.Log("Boss 4. aþamaya geçti!");
        // Son aþamada boss'un saldýrýlarý daha da güçlenebilir
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Boss hasar aldý! Kalan can: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Boss öldü!");
        // Boss öldüðünde yapýlacaklar (örn. animasyon, efektler)
    }
}
