using UnityEngine;

public class ThanhQuay : MonoBehaviour
{
    private bool isRotating = false;
    private Transform pivot;
    public float speed = 100f;

    public Transform pointA, pointB;
    public Transform[] diemDung;
    public float stopThreshold = 0.5f;

    // Thêm biến kiểm tra đã rời khỏi tâm chưa
    private bool hasLeftPivot = false;
    public float leaveThreshold = 0.1f; // khoảng cách để xác nhận đã rời tâm

    public bool IsRotating => isRotating;
    public Transform CurrentPivot => pivot;

    void Update()
    {
        if (isRotating && pivot != null)
        {
            transform.RotateAround(pivot.position, Vector3.forward, speed * Time.deltaTime);

            Transform diemDangQuay = (pivot == pointA) ? pointB : pointA;

            float distanceFromPivot = Vector3.Distance(diemDangQuay.position, pivot.position);

            if (!hasLeftPivot)
            {
                // Kiểm tra xem điểm còn lại đã rời khỏi tâm đủ chưa
                if (distanceFromPivot > leaveThreshold)
                {
                    hasLeftPivot = true;
                    Debug.Log($"{diemDangQuay.name} đã rời khỏi tâm {pivot.name}");
                }
            }
            else
            {
                // Đã rời tâm, bắt đầu kiểm tra va chạm với điểm dừng
                foreach (Transform diem in diemDung)
                {
                    if (Vector3.Distance(diemDangQuay.position, diem.position) <= stopThreshold)
                    {
                        Debug.Log($"{diemDangQuay.name} chạm {diem.name}, dừng quay");
                        StopRotation();
                        break;
                    }
                }
            }
        }
    }

    public void SetPivot(Transform newPivot)
    {
        if (!isRotating)
        {
            pivot = newPivot;
            isRotating = true;
            hasLeftPivot = false; // reset trạng thái mỗi lần bắt đầu quay
            Debug.Log("Bắt đầu quay quanh: " + pivot.name);
        }
    }

    public void StopRotation()
    {
        isRotating = false;
        pivot = null;
        hasLeftPivot = false;
        Debug.Log("Dừng quay");
    }
}
