using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform pointA; // Điểm A (gán trong Inspector)
    public Transform pointB; // Điểm B (gán trong Inspector)

    void Update()
    {
        if (pointA != null && pointB != null)
        {
            float distance = Vector3.Distance(pointA.position, pointB.position);
            Debug.Log("Khoảng cách giữa A và B: " + distance);
        }
        else
        {
            Debug.LogWarning("Chưa gán pointA hoặc pointB trong Inspector!");
        }
    }
}
