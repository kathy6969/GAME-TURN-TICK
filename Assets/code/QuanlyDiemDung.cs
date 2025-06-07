using UnityEngine;

public class QuanLyDiemDung : MonoBehaviour
{
    public Transform[] diemDung;

    public bool KiemTraChamDiem(Transform diemKiemTra, float stopThreshold)
    {
        if (diemDung == null || diemDung.Length == 0)
            return false;

        foreach (Transform diem in diemDung)
        {
            float dist = Vector3.Distance(diemKiemTra.position, diem.position);
            if (dist <= stopThreshold)
            {
                var kichHoat = diem.GetComponent<DiemDungCoKichHoat>();
                // Nếu không có component DiemDungCoKichHoat hoặc đã được kích hoạt mới trả về true
                if (kichHoat == null || kichHoat.duocKichHoat)
                    return true;
            }
        }
        return false;
    }
}
