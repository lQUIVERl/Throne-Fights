using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreen; // Ölüm ekraný paneli
    public Text scoreText;         // Skoru gösterecek text
    private int score = 0;         // Skor

    void Start()
    {
        deathScreen.SetActive(false); // Baþlangýçta paneli kapalý tut
    }

    public void ShowDeathScreen(int finalScore)
    {
        score = finalScore;
        scoreText.text = "Score: " + score.ToString();
        deathScreen.SetActive(true); // Paneli aktif et
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine dön
    }
}
