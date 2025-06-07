using UnityEngine;

public class ChuongKichHoat : MonoBehaviour
{
    public DiemDungCoKichHoat diemLienKet;

    // SpriteRenderer và 2 sprite cho chuông
    public Sprite spriteChuaKichHoat;
    public Sprite spriteDaKichHoat;

    private SpriteRenderer spriteRenderer;
    private bool duocKichHoat = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CapNhatHinh();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ThanhQuay"))
        {
            // Toggle trạng thái chuông
            duocKichHoat = !duocKichHoat;
            CapNhatHinh();

            // Toggle trạng thái điểm dừng liên kết
            if (diemLienKet != null)
            {
                diemLienKet.ToggleKichHoat();
            }

            Debug.Log("Chuông đã được kích hoạt/tắt và điểm dừng cũng đổi trạng thái.");
        }
    }

    void CapNhatHinh()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = duocKichHoat ? spriteDaKichHoat : spriteChuaKichHoat;
    }
}
