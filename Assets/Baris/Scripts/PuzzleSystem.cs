using UnityEngine;
using UnityEngine.UI;

public class PuzzleSystem : MonoBehaviour
{
    public Button buttonS; // 's' butonu
    public Button buttonI; // 'ý' butonu
    public Button buttonR; // 'r' butonu
    public GameObject door; // Açýlacak kapý
    public GameObject buttonSObject; // 'S' buton GameObject'i
    public GameObject buttonIObject; // 'I' buton GameObject'i
    public GameObject buttonRObject; // 'R' buton GameObject'i

    private string correctSequence = "SIR"; // Doðru sýra
    private string inputSequence = ""; // Kullanýcýnýn girdiði sýra

    void Start()
    {
        // Butonlara týklama olaylarýný ekliyoruz
        buttonS.onClick.AddListener(() => AddToSequence("S"));
        buttonI.onClick.AddListener(() => AddToSequence("I"));
        buttonR.onClick.AddListener(() => AddToSequence("R"));
    }

    // Týklanan butonu sýraya ekleyen fonksiyon
    void AddToSequence(string letter)
    {
        inputSequence += letter;

        if (inputSequence.Length == correctSequence.Length)
        {
            if (inputSequence == correctSequence)
            {
                OpenDoor(); // Sýra doðruysa kapýyý aç
            }
            else
            {
                ResetSequence(); // Yanlýþsa sýfýrla
            }
        }
    }

    // Kapýyý açan fonksiyon
    void OpenDoor()
    {
        door.SetActive(false); // Kapýyý kapatarak açýlmýþ gibi göster
        Debug.Log("Kapý açýldý!");

        // Butonlarý gizle
        buttonSObject.SetActive(false);
        buttonIObject.SetActive(false);
        buttonRObject.SetActive(false);
    }

    // Sýralamayý sýfýrlayan fonksiyon
    void ResetSequence()
    {
        inputSequence = "";
        Debug.Log("Yanlýþ sýra! Tekrar dene.");
    }
}
