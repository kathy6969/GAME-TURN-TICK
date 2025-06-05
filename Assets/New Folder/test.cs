using UnityEngine;

public class TestVaCham : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Va chạm với: " + other.name);
    }
}
