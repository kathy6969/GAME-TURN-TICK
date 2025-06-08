using UnityEngine;
using UnityEngine.SceneManagement; // Thêm namespace để load scene
using System.Collections; // Cho Coroutine

public class ThanhEnd : MonoBehaviour
{
    private bool daChamA = false;
    private bool daChamB = false;

    public ThanhQuay thanhQuay;
    public DiemSoUIManager diemSoUI;

    [Header("Tên màn kế tiếp (gán trong Inspector)")]
    public string tenManKeTiep;

    [Header("Thời gian đợi trước khi chuyển màn (giây)")]
    public float thoiGianDoiChuyenMan = 5f;

    private bool daChuyenMan = false; // Để tránh gọi chuyển nhiều lần

    void OnTriggerEnter2D(Collider2D other)
    {
        if (daChuyenMan) return; // Nếu đang chuẩn bị chuyển màn thì thôi

        if (other.CompareTag("pointA"))
        {
            daChamA = true;
        }
        else if (other.CompareTag("pointB"))
        {
            daChamB = true;
        }

        if (daChamA && daChamB)
        {
            if (thanhQuay != null)
            {
                thanhQuay.StopRotation();

                float thoiGianChoi = Time.time - thanhQuay.GetStartTime();

                if (diemSoUI != null)
                {
                    diemSoUI.CapNhatThoiGian(thoiGianChoi);
                    diemSoUI.CapNhatDiemCao(thoiGianChoi);
                }
            }

            daChuyenMan = true;
            StartCoroutine(ChuyenManSauThoiGian(thoiGianDoiChuyenMan));
        }
    }

    private IEnumerator ChuyenManSauThoiGian(float thoiGian)
    {
        yield return new WaitForSeconds(thoiGian);

        if (!string.IsNullOrEmpty(tenManKeTiep))
        {
            SceneManager.LoadScene(tenManKeTiep);
        }
        else
        {
            Debug.LogWarning("Tên màn kế tiếp chưa được đặt trong Inspector!");
        }
    }
}
