using UnityEngine;

public class DiemDungVisualizer : MonoBehaviour
{
    public float radius = 0.3f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
