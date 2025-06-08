using UnityEngine;

public class ThanhQuay : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 100f;
    public float stopThreshold = 0.5f;
    public float leaveThreshold = 0.2f;

    public QuanLyDiemDung quanLyDiemDung;

    public AudioClip amThanhDungLai;
    private AudioSource audioSource;

    private bool isRotating = false;
    private Transform pivot;

    private bool hasLeftStart = false;
    private Vector3 startPosition;

    private float startTime;
    public float GetStartTime() => startTime;

    public bool IsRotating => isRotating;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

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
                }
            }
            else
            {
                if (quanLyDiemDung != null && quanLyDiemDung.KiemTraChamDiem(diemDangQuay, stopThreshold))
                {
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
            startPosition = (pivot == pointA) ? pointB.position : pointA.position;

            startTime = Time.time;  // Ghi lại thời gian bắt đầu quay
        }
    }

    public void StopRotation()
    {
        isRotating = false;
        pivot = null;

        if (amThanhDungLai != null && audioSource != null)
        {
            audioSource.PlayOneShot(amThanhDungLai);
        }
    }

    // Hàm mới trả về thời gian đã quay (giây)
    public float GetElapsedTime()
    {
        if (!isRotating)
        {
            // Nếu đang dừng thì trả về thời gian tính từ start đến bây giờ
            return Time.time - startTime;
        }
        else
        {
            // Nếu đang quay thì trả về thời gian hiện tại
            return Time.time - startTime;
        }
    }
}
