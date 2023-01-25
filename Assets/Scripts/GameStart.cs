using Player.Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        FindObjectOfType<WindowManager>().HideStartWindow();
        FindObjectOfType<PlayerBehaviour>().EnableInput();
    }
}