using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName; // Bir sonraki sahnenin adý

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Oyuncunun temas ettiðini kontrol et
        {
            SceneManager.LoadScene(nextSceneName); // Bir sonraki sahneye geçiþ yap
        }
    }
}

