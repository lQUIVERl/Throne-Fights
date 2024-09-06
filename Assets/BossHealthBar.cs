using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Health bossHealth; // Boss'un Health scripti
    [SerializeField] Image healthBarFill; // Can çubuðunu dolduran UI Image
    [SerializeField] Vector3 offset; // Can çubuðunun boss'un üzerinde görünmesi için

    private void Update()
    {
        // Can çubuðunu boss'un konumuna göre ayarla
        transform.position = bossHealth.transform.position + offset;

        // Can çubuðunu boss'un mevcut saðlýðýna göre doldur
        healthBarFill.fillAmount = (float)bossHealth.CurrentHealt / bossHealth.MaxHealt;

        // Eðer boss'un caný sýfýrsa, can çubuðunu gizle
        if (bossHealth.CurrentHealt <= 0)
        {
            gameObject.SetActive(false); // Can çubuðunu gizle
        }
    }
}
