using Player.Behaviours;
using UnityEngine;
using Utility;

namespace Finish
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;
        
        private WindowDisplayer _windowDisplayer;

        private void Start()
        {
            _windowDisplayer = FindObjectOfType<WindowDisplayer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();

            if (playerBehaviour != null)
            {
                playerBehaviour.StartFinishBehabiour();
                _windowDisplayer.ShowFinishWindow();
            }
        
            _soundPlayer.Play();
        }
    }
}