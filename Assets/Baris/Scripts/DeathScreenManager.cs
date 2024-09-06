using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreen; // �l�m ekran� paneli
    public Text scoreText;         // Skoru g�sterecek text
    private int score = 0;         // Skor

    void Start()
    {
        deathScreen.SetActive(false); // Ba�lang��ta paneli kapal� tut
    }

    public void ShowDeathScreen(int finalScore)
    {
        score = finalScore;
        scoreText.text = "Score: " + score.ToString();
        deathScreen.SetActive(true); // Paneli aktif et
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden y�kle
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Ana men� sahnesine d�n
    }
}
