//using UnityEngine;

//public class TutorialManager : MonoBehaviour
//{
//    public GameObject huongDanPanel; // Gán HuongDan
//    public GameObject[] tutorialSteps; // DiChuyen, TanCong...
//    private int currentStep = 0;

//    private void Start()
//    {
//        huongDanPanel.SetActive(true); // Hiện cả Panel hướng dẫn
//        ShowStep(0); // Hiện bước đầu tiên (DiChuyen)
//    }

//    public void ShowNextStep()
//    {
//        if (currentStep < tutorialSteps.Length - 1)
//        {
//            tutorialSteps[currentStep].SetActive(false);
//            currentStep++;
//            tutorialSteps[currentStep].SetActive(true);
//        }
//        else
//        {
//            tutorialSteps[currentStep].SetActive(false);
//            huongDanPanel.SetActive(false); // Ẩn hết hướng dẫn
//            Debug.Log("Hướng dẫn kết thúc.");
//        }
//    }

//    private void ShowStep(int index)
//    {
//        for (int i = 0; i < tutorialSteps.Length; i++)
//        {
//            tutorialSteps[i].SetActive(i == index);
//        }
//    }
//}


using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject huongDanPanel;
    public GameObject[] tutorialSteps;
    private int currentStep = 0;

    private void Start()
    {
        Time.timeScale = 0f; // Dừng game lại
        huongDanPanel.SetActive(true);
        ShowStep(0);
    }

    public void ShowNextStep()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            tutorialSteps[currentStep].SetActive(false);
            currentStep++;
            tutorialSteps[currentStep].SetActive(true);
        }
        else
        {
            tutorialSteps[currentStep].SetActive(false);
            huongDanPanel.SetActive(false);
            Time.timeScale = 1f; // Tiếp tục game sau hướng dẫn
            Debug.Log("Hướng dẫn kết thúc.");
        }
    }

    private void ShowStep(int index)
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == index);
        }
    }
}
