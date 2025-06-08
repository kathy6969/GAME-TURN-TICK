using UnityEngine;
using TMPro;

public class DiemSoUIManager : MonoBehaviour
{
    [Header("Tham chiếu UI")]
    [SerializeField] private TextMeshProUGUI tmpThoiGian;
    [SerializeField] private TextMeshProUGUI tmpDiemCao;

    [Header("Màu sắc")]
    [SerializeField] private Color mauChuMacDinh = Color.black;
    [SerializeField] private Color mauDiemCaoMoi = Color.red; // Màu khi phá kỷ lục

    private const string HIGH_SCORE_KEY = "HighScore";

    void Start()
    {
        HienThiDiemCaoHienTai();
    }

    public void CapNhatThoiGian(float thoiGian)
    {
        if (tmpThoiGian == null) return;

        tmpThoiGian.text = $"Thời gian: {thoiGian:F2}s";
        tmpThoiGian.color = mauChuMacDinh;
    }

    public void CapNhatDiemCao(float diemMoi)
    {
        float diemCaoHienTai = LayDiemCao();
        bool laKyLucMoi = false;

        if (diemMoi < diemCaoHienTai)
        {
            LuuDiemCao(diemMoi);
            laKyLucMoi = true;
        }

        if (tmpDiemCao != null)
        {
            tmpDiemCao.text = $"Kỷ lục: {(laKyLucMoi ? diemMoi : diemCaoHienTai):F2}s";
            tmpDiemCao.color = laKyLucMoi ? mauDiemCaoMoi : mauChuMacDinh;
        }
    }

    public void ResetDiemCao()
    {
        PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
        HienThiDiemCaoHienTai();
    }

    public void HienThiDiemCaoHienTai()
    {
        if (tmpDiemCao == null) return;

        float diemCao = LayDiemCao();
        tmpDiemCao.text = diemCao == float.MaxValue ? "Kỷ lục: --" : $"Kỷ lục: {diemCao:F2}s";
        tmpDiemCao.color = mauChuMacDinh;
    }

    // Helper methods
    private float LayDiemCao()
    {
        return PlayerPrefs.GetFloat(HIGH_SCORE_KEY, float.MaxValue);
    }

    private void LuuDiemCao(float diem)
    {
        PlayerPrefs.SetFloat(HIGH_SCORE_KEY, diem);
        PlayerPrefs.Save();
    }
}