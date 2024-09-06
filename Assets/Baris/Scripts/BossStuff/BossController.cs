using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth = 300; // Boss'un toplam can�
    private int currentHealth;

    public GameObject player; // Oyuncu referans�
    public Transform[] attackPoints; // Sald�r� noktalar�

    public GameObject projectile; // Boss'un att��� uzaktan sald�r� objesi
    public GameObject shield; // Boss�un kalkan� (e�er varsa)

    public float attackCooldown = 2f; // Sald�r�lar aras� bekleme s�resi
    private float attackTimer = 0f;

    private int phase = 1; // Boss'un mevcut a�amas�

    void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta boss'un can�n� en �st seviyeye ayarl�yoruz
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                AttackPlayer(); // Sald�r�y� ger�ekle�tir
                attackTimer = 0f; // Zamanlay�c�y� s�f�rla
            }

            // A�amalar aras�nda ge�i�
            CheckPhase();
        }
        else
        {
            Die(); // Boss �ld�
        }
    }

    void AttackPlayer()
    {
        // Boss'un farkl� sald�r�lar yapmas�n� sa�layan bir sald�r� sistemi
        int randomAttack = Random.Range(0, 3); // 0: Yak�n sald�r�, 1: Uzak sald�r�, 2: Alan etkili sald�r�
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
        Debug.Log("Boss yak�n sald�r� yap�yor!");
        // Boss oyuncuya do�ru hamle yaparak yak�n sald�r� ger�ekle�tirir
        // (Buraya boss'un oyuncuya do�ru h�zla hareket etti�i bir kod eklenebilir)
    }

    void RangedAttack()
    {
        Debug.Log("Boss uzak sald�r� yap�yor!");
        // Uzak sald�r� i�in bir projectile f�rlat�yoruz
        foreach (Transform attackPoint in attackPoints)
        {
            Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        }
    }

    void AreaAttack()
    {
        Debug.Log("Boss alan sald�r�s� yap�yor!");
        // Yerden ��kan dikenler gibi bir alan sald�r�s� ger�ekle�tirilebilir
    }

    void CheckPhase()
    {
        // Boss'un a�amalar aras�nda ge�i� yapmas�n� sa�layan sistem
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
        Debug.Log("Boss 2. a�amaya ge�ti!");
        // 2. a�amaya ge�ti�inde yeni sald�r�lar ekleyebiliriz
    }

    void EnterPhase3()
    {
        phase = 3;
        Debug.Log("Boss 3. a�amaya ge�ti!");
        // 3. a�amaya ge�ti�inde savunma mekani�i ekleyebiliriz (�rne�in kalkan)
        shield.SetActive(true); // Kalkan etkinle�tirilebilir
    }

    void EnterPhase4()
    {
        phase = 4;
        Debug.Log("Boss 4. a�amaya ge�ti!");
        // Son a�amada boss'un sald�r�lar� daha da g��lenebilir
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Boss hasar ald�! Kalan can: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Boss �ld�!");
        // Boss �ld���nde yap�lacaklar (�rn. animasyon, efektler)
    }
}
