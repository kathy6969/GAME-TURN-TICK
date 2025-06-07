using UnityEngine;
using TMPro;

public class TMP_HienThi10s : MonoBehaviour
{
    public TextMeshProUGUI uiText;     // Kéo TextMeshProUGUI vào đây
    public float thoiGianHien = 10f;   // Thời gian hiển thị tính bằng giây

    void OnEnable()
    {
        if (uiText != null)
        {
            uiText.gameObject.SetActive(true);
            uiText.color = Color.black; 

            CancelInvoke(nameof(AnText));
            Invoke(nameof(AnText), thoiGianHien);
        }
    }

    void AnText()
    {
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }
}
