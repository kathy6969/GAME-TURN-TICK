using UnityEngine;

public class QuanLyDiemDung : MonoBehaviour
{
    public Transform[] diemDung;

    public bool KiemTraChamDiem(Transform diemKiemTra, float stopThreshold)
    {
        foreach (Transform diem in diemDung)
        {
            float dist = Vector3.Distance(diemKiemTra.position, diem.position);
            if (dist <= stopThreshold)
                return true;
        }
        return false;
    }
}
