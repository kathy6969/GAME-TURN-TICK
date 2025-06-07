using UnityEngine;

public class DiemDungCoKichHoat : MonoBehaviour
{
    public bool duocKichHoat = false;
    public Sprite spriteDaKichHoat;
    public Sprite spriteChuaKichHoat;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        CapNhatHinh();
    }

    public void SetKichHoat(bool state)
    {
        duocKichHoat = state;
        CapNhatHinh();
    }

    public void ToggleKichHoat()
    {
        duocKichHoat = !duocKichHoat;
        CapNhatHinh();
    }

    void CapNhatHinh()
    {
        if (sr != null)
            sr.sprite = duocKichHoat ? spriteDaKichHoat : spriteChuaKichHoat;
    }
}
