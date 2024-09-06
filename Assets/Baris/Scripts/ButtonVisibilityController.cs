using UnityEngine;

public class ButtonVisibilityController : MonoBehaviour
{
    public GameObject buttonS; // 'S' butonu
    public GameObject buttonI; // 'I' butonu
    public GameObject buttonR; // 'R' butonu
    public GameObject player; // Oyuncu
    public GameObject door; // Kapý

    public float activationDistance = 5f; // Butonlarýn görünmesi için gereken mesafe

    void Update()
    {
        // Kapý ile oyuncu arasýndaki mesafeyi hesapla
        float distance = Vector3.Distance(player.transform.position, door.transform.position);

        // Eðer oyuncu kapýya yeterince yakýnsa butonlarý göster
        if (distance < activationDistance)
        {
            ShowButtons(true);
        }
        else
        {
            ShowButtons(false);
        }
    }

    // Butonlarý aktif veya pasif hale getiren fonksiyon
    void ShowButtons(bool show)
    {
        buttonS.SetActive(show);
        buttonI.SetActive(show);
        buttonR.SetActive(show);
    }
}

