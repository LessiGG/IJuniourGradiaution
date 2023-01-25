using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _finishWindow;

    public void HideStartWindow()
    {
        _startWindow.SetActive(false);
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }
}