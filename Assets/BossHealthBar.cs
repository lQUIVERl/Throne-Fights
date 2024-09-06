using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Health bossHealth; // Boss'un Health scripti
    [SerializeField] Image healthBarFill; // Can �ubu�unu dolduran UI Image
    [SerializeField] Vector3 offset; // Can �ubu�unun boss'un �zerinde g�r�nmesi i�in

    private void Update()
    {
        // Can �ubu�unu boss'un konumuna g�re ayarla
        transform.position = bossHealth.transform.position + offset;

        // Can �ubu�unu boss'un mevcut sa�l���na g�re doldur
        healthBarFill.fillAmount = (float)bossHealth.CurrentHealt / bossHealth.MaxHealt;

        // E�er boss'un can� s�f�rsa, can �ubu�unu gizle
        if (bossHealth.CurrentHealt <= 0)
        {
            gameObject.SetActive(false); // Can �ubu�unu gizle
        }
    }
}
