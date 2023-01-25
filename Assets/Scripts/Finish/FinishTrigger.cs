using Player.Behaviours;
using UnityEngine;
using Utility;

namespace Finish
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;
        
        private void OnTriggerEnter(Collider other)
        {
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();

            if (playerBehaviour != null)
            {
                playerBehaviour.StartFinishBehabiour();
                FindObjectOfType<WindowManager>().ShowFinishWindow();
            }
        
            _soundPlayer.Play();
        }
    }
}