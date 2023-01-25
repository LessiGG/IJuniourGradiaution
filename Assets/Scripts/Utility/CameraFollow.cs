using UnityEngine;

namespace Utility
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Start()
        {
            transform.parent = null;
        }

        private void LateUpdate()
        {
            if (_target != null)
                transform.position = _target.position;
        }
    }
}