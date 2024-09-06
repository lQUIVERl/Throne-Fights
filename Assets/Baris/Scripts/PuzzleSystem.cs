using UnityEngine;
using UnityEngine.UI;

public class PuzzleSystem : MonoBehaviour
{
    public Button buttonS; // 's' butonu
    public Button buttonI; // '�' butonu
    public Button buttonR; // 'r' butonu
    public GameObject door; // A��lacak kap�
    public GameObject buttonSObject; // 'S' buton GameObject'i
    public GameObject buttonIObject; // 'I' buton GameObject'i
    public GameObject buttonRObject; // 'R' buton GameObject'i

    private string correctSequence = "SIR"; // Do�ru s�ra
    private string inputSequence = ""; // Kullan�c�n�n girdi�i s�ra

    void Start()
    {
        // Butonlara t�klama olaylar�n� ekliyoruz
        buttonS.onClick.AddListener(() => AddToSequence("S"));
        buttonI.onClick.AddListener(() => AddToSequence("I"));
        buttonR.onClick.AddListener(() => AddToSequence("R"));
    }

    // T�klanan butonu s�raya ekleyen fonksiyon
    void AddToSequence(string letter)
    {
        inputSequence += letter;

        if (inputSequence.Length == correctSequence.Length)
        {
            if (inputSequence == correctSequence)
            {
                OpenDoor(); // S�ra do�ruysa kap�y� a�
            }
            else
            {
                ResetSequence(); // Yanl��sa s�f�rla
            }
        }
    }

    // Kap�y� a�an fonksiyon
    void OpenDoor()
    {
        door.SetActive(false); // Kap�y� kapatarak a��lm�� gibi g�ster
        Debug.Log("Kap� a��ld�!");

        // Butonlar� gizle
        buttonSObject.SetActive(false);
        buttonIObject.SetActive(false);
        buttonRObject.SetActive(false);
    }

    // S�ralamay� s�f�rlayan fonksiyon
    void ResetSequence()
    {
        inputSequence = "";
        Debug.Log("Yanl�� s�ra! Tekrar dene.");
    }
}
