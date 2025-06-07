using UnityEngine;

public class ThanhEnd : MonoBehaviour
{
    private bool daChamA = false;
    private bool daChamB = false;

    public ThanhQuay thanhQuay; // Gắn từ Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pointA"))
        {
            daChamA = true;
            Debug.Log("Point A đã chạm thanhEnd");
        }
        else if (other.CompareTag("pointB"))
        {
            daChamB = true;
            Debug.Log("Point B đã chạm thanhEnd");
        }

        if (daChamA && daChamB)
        {
            Debug.Log("🏆 WIN: Cả A và B đã chạm thanhEnd");
            if (thanhQuay != null)
                thanhQuay.StopRotation();
        }
    }
}
