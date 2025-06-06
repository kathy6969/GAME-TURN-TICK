using UnityEngine;

public class ThanhQuay : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 100f;
    public float stopThreshold = 0.5f;
    public float leaveThreshold = 0.2f;

    public QuanLyDiemDung quanLyDiemDung;

    private bool isRotating = false;
    private Transform pivot;

    private bool hasLeftStart = false;
    private Vector3 startPosition;

    public bool IsRotating => isRotating;

    void Update()
    {
        if (isRotating && pivot != null)
        {
            transform.RotateAround(pivot.position, Vector3.forward, speed * Time.deltaTime);

            Transform diemDangQuay = (pivot == pointA) ? pointB : pointA;

            float distance = Vector3.Distance(diemDangQuay.position, startPosition);

            if (!hasLeftStart)
            {
                if (distance > leaveThreshold)
                {
                    hasLeftStart = true;
                    Debug.Log("Đã rời khỏi vị trí bắt đầu");
                }
            }
            else
            {
                if (quanLyDiemDung != null && quanLyDiemDung.KiemTraChamDiem(diemDangQuay, stopThreshold))
                {
                    Debug.Log($"{diemDangQuay.name} chạm điểm dừng, DỪNG QUAY");
                    StopRotation();
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
            hasLeftStart = false;

            // Ghi nhớ vị trí bắt đầu của điểm kia
            startPosition = (pivot == pointA) ? pointB.position : pointA.position;

            Debug.Log("Bắt đầu quay quanh: " + pivot.name);
        }
    }

    public void StopRotation()
    {
        isRotating = false;
        pivot = null;
    }
}
