using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject bloodParticle;
    [SerializeField] public int MaxHealt, CurrentHealt;
    [SerializeField] GameObject gameOverPanel; // Game Over paneli
    [SerializeField] string menuSceneName = "MenuSceneName"; // Men� sahnesinin ad�

    private void Start()
    {
        CurrentHealt = MaxHealt;
        gameOverPanel.SetActive(false); // Ba�lang��ta Game Over panelini gizle
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

    [SerializeField] GameObject healthBarUI; // Boss'un can �ubu�u UI'si

    private void Die()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            gameOverPanel.SetActive(true); // Game Over panelini g�ster
            Time.timeScale = 0f; // Oyunu durdur
        }
        else
        {
            if (healthBarUI != null)
            {
                healthBarUI.SetActive(false); // Can �ubu�unu gizle
            }
            Destroy(gameObject); // Boss'u yok et
        }
    }

    public void Respawn()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Ge�erli sahneyi yeniden y�kle
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        SceneManager.LoadScene("MainMenu"); // Men� sahnesini y�kle
    }
}
