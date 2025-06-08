using UnityEngine;

public class ChuongKichHoat : MonoBehaviour
{
    public DiemDungCoKichHoat diemLienKet;

    public Sprite spriteChuaKichHoat;
    public Sprite spriteDaKichHoat;

    public AudioClip amThanhChuong; // Âm thanh khi chạm vào chuông
    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    private bool duocKichHoat = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        CapNhatHinh();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ThanhQuay"))
        {
            duocKichHoat = !duocKichHoat;
            CapNhatHinh();

            if (diemLienKet != null)
            {
                diemLienKet.ToggleKichHoat();
            }

            if (amThanhChuong != null && audioSource != null)
            {
                audioSource.PlayOneShot(amThanhChuong);
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
