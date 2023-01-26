using Coins;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FinishGameWindow : MonoBehaviour
{
    [SerializeField] private CoinsHolder _coinsHolder;
    
    private Button _nextLevelButton;

    private void OnEnable()
    {
        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        _nextLevelButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        MoveToNextLevel();
    }

    private void MoveToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            _coinsHolder.SaveProgress();
            SceneManager.LoadScene(nextSceneIndex);
        }
    } 
}