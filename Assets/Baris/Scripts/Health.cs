using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject bloodParticle;
    [SerializeField] public int MaxHealt, CurrentHealt;
    [SerializeField] GameObject gameOverPanel; // Game Over paneli
    [SerializeField] string menuSceneName = "MenuSceneName"; // Menü sahnesinin adý

    private void Start()
    {
        CurrentHealt = MaxHealt;
        gameOverPanel.SetActive(false); // Baþlangýçta Game Over panelini gizle
    }

    public void TakeDamage(int damage)
    {
        CurrentHealt -= damage;
        Instantiate(bloodParticle, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        if (CurrentHealt <= 0)
        {
            Die();
        }
    }

    [SerializeField] GameObject healthBarUI; // Boss'un can çubuðu UI'si

    private void Die()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            gameOverPanel.SetActive(true); // Game Over panelini göster
            Time.timeScale = 0f; // Oyunu durdur
        }
        else
        {
            if (healthBarUI != null)
            {
                healthBarUI.SetActive(false); // Can çubuðunu gizle
            }
            Destroy(gameObject); // Boss'u yok et
        }
    }

    public void Respawn()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Geçerli sahneyi yeniden yükle
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        SceneManager.LoadScene("MainMenu"); // Menü sahnesini yükle
    }
}
