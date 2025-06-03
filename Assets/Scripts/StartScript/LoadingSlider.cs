using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] private GameObject panelLoading; // Panel chứa slider
    [SerializeField] private GameObject startButton;  // Nút bắt đầu game
    [SerializeField] private Slider slider;           // Thanh trượt loading
    [SerializeField] private float duration = 3f;     // Thời gian loading (giây)
    [SerializeField] private float buttonScaleDuration = 0.35f; // Thời gian hiệu ứng scale nút
    private const float maxValue = 100;              // Giá trị tối đa của slider
    private float value;                             // Giá trị hiện tại của slider

    void Start()
    {
        // Kiểm tra null
        if (panelLoading == null || startButton == null || slider == null)
        {
            Debug.LogError("Missing references in LoadingSlider! Please assign panelLoading, startButton, and slider in the Inspector.");
            return;
        }

        // Đặt giá trị tối đa cho slider
        slider.maxValue = maxValue;
        slider.value = 0; // Đặt giá trị ban đầu

        // Bắt đầu animation cho slider
        DOTween.To(() => value, x => value = x, maxValue, duration).OnUpdate(() =>
        {
            slider.value = value; // Cập nhật slider trong quá trình animation
        }).OnComplete(() =>
        {
            // Ẩn panel loading
            panelLoading.SetActive(false);

            // Hiển thị nút bắt đầu với hiệu ứng scale
            startButton.SetActive(true);
            startButton.transform.localScale = Vector3.zero; // Bắt đầu từ kích thước 0
            startButton.transform.DOScale(1f, buttonScaleDuration).SetEase(Ease.OutBounce);
        });
    }

    public void Play()
    {
        SceneManager.LoadScene(1); // Chuyển sang scene menu level
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}