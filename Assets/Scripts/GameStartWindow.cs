using Player.Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameStartWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private WindowDisplayer _windowDisplayer;
    
    private PlayerBehaviour _playerBehaviour;
    private Button _playButton;

    private void OnEnable()
    {
        _playButton = GetComponent<Button>();
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        _playButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Play();
    }

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    private void Play()
    {
        _windowDisplayer.HideStartWindow();
        _playerBehaviour.EnableInput();
    }
}