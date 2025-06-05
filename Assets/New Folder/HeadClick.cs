using UnityEngine;

public class HeadClick : MonoBehaviour
{
    public ThanhQuay thanhQuay;

    void OnMouseDown()
    {
        if (thanhQuay != null && !thanhQuay.IsRotating)
        {
            Debug.Log("Đã click vào: " + gameObject.name);
            thanhQuay.SetPivot(this.transform);
        }
        else
        {
            Debug.Log("Đang quay, không thể click.");
        }
    }
}
