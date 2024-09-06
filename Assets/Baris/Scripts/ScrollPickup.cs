using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollPickup : MonoBehaviour
{
    public GameObject scrollUIPanel;
    public TMP_Text ScrollText;
    public string message; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         
            ScrollText.text = message;
            scrollUIPanel.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scrollUIPanel.SetActive(false);
        }
    }
}
