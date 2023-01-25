using Coins;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    
    public void MoveToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveProgress();
            SceneManager.LoadScene(nextSceneIndex);
        }
    } 
}