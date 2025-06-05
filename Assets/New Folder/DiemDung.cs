using UnityEngine;

public class DiemDung : MonoBehaviour
{
    public ThanhQuay thanhQuay; // kéo vào Inspector
    public string diemCanDung = "PointA"; // tên điểm pivot tương ứng (pointA hoặc pointB)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra điều kiện an toàn
        if (thanhQuay == null) return;

        // Lấy pivot hiện tại
        Transform currentPivot = thanhQuay.CurrentPivot;
        if (currentPivot == null) return;

        // Kiểm tra collider chạm là điểm A hoặc B
        if (other.transform == currentPivot)
        {
            // Nếu đang quay thì dừng lại
            if (thanhQuay.IsRotating)
            {
                Debug.Log("Điểm " + diemCanDung + " chạm " + gameObject.name + ", dừng quay.");
                thanhQuay.StopRotation();
            }
        }
    }
}
