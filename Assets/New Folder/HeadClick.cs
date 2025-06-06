using UnityEngine;

public class HeadClick : MonoBehaviour
{
    public ThanhQuay thanhQuay;
    public Transform diem;

    void OnMouseDown()
    {
        if (thanhQuay != null && !thanhQuay.IsRotating)
        {
            thanhQuay.SetPivot(diem);
        }
    }
}
