using UnityEngine;

public class ButtonVisibilityController : MonoBehaviour
{
    public GameObject buttonS; // 'S' butonu
    public GameObject buttonI; // 'I' butonu
    public GameObject buttonR; // 'R' butonu
    public GameObject player; // Oyuncu
    public GameObject door; // Kap�

    public float activationDistance = 5f; // Butonlar�n g�r�nmesi i�in gereken mesafe

    void Update()
    {
        // Kap� ile oyuncu aras�ndaki mesafeyi hesapla
        float distance = Vector3.Distance(player.transform.position, door.transform.position);

        // E�er oyuncu kap�ya yeterince yak�nsa butonlar� g�ster
        if (distance < activationDistance)
        {
            ShowButtons(true);
        }
        else
        {
            ShowButtons(false);
        }
    }

    // Butonlar� aktif veya pasif hale getiren fonksiyon
    void ShowButtons(bool show)
    {
        buttonS.SetActive(show);
        buttonI.SetActive(show);
        buttonR.SetActive(show);
    }
}

