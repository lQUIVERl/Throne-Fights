using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName; // Bir sonraki sahnenin ad�

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Oyuncunun temas etti�ini kontrol et
        {
            SceneManager.LoadScene(nextSceneName); // Bir sonraki sahneye ge�i� yap
        }
    }
}

