using UnityEngine;

namespace Player.Behaviours
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PreFinishBehaviour))]
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
    
        private PlayerMovement _playerMovement;
        private PreFinishBehaviour _preFinishBehaviour;
    
        private static readonly int StartDancingKey = Animator.StringToHash("startDancing");

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _preFinishBehaviour = GetComponent<PreFinishBehaviour>();
        }

        private void Start()
        {
            DisableInput();
            DisablePreFinishBehaviour();
        }

        public void EnableInput()
        {
            _playerMovement.enabled = true;
        }

        public void StartPreFinishBehabiour()
        {
            DisableInput();
            EnablePreFinishBehaviour();
        }

        public void StartFinishBehabiour()
        {
            DisablePreFinishBehaviour();
            StartDancing();
        }

        private void DisableInput()
        {
            _playerMovement.enabled = false;
        }

        private void EnablePreFinishBehaviour()
        {
            _preFinishBehaviour.enabled = true;
        }
        private void DisablePreFinishBehaviour()
        {
            _preFinishBehaviour.enabled = false;
        }

        private void StartDancing()
        {
            _animator.SetTrigger(StartDancingKey);
        }
    }
}