using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonChuyenScene : MonoBehaviour
{
    [Tooltip("Tên scene để chuyển đến khi nhấn nút")]
    public string tenScene;

    void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChuyenScene);
    }

    void ChuyenScene()
    {
        if (!string.IsNullOrEmpty(tenScene))
        {
            SceneManager.LoadScene(tenScene);
        }
        else
        {
            Debug.LogWarning("⚠️ tenScene chưa được gán!");
        }
    }
}
