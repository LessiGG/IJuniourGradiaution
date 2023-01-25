using Player.Behaviours;
using UnityEngine;

namespace Finish
{
    public class PreFinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerBehaviour playerBehaviour = other.attachedRigidbody.GetComponent<PlayerBehaviour>();

            if (playerBehaviour != null)
            {
                playerBehaviour.StartPreFinishBehabiour();
            }
        }
    }
}