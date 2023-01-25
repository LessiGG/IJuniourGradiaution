using UnityEngine;

namespace Player.Behaviours
{
    public class PreFinishBehaviour : MonoBehaviour
    {
        [SerializeField] private float _toCenterSpeed = 2f;
        [SerializeField] private float _turningSpeed = 100f;
        [SerializeField] private float _speed;
    
        private void Update()
        {
            MoveToCenter();
            RotateToLookForward();
        }

        private void MoveToCenter()
        {
            float x = Mathf.MoveTowards(transform.position.x, 0, _toCenterSpeed * Time.deltaTime);
            float z = transform.position.z + _speed * Time.deltaTime;
            transform.position = new Vector3(x, 0, z);
        }

        private void RotateToLookForward()
        {
            float rotation = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, _turningSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, rotation, 0);
        }
    }
}