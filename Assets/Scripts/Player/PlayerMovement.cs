using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _limitRotationAngle = 70f;
        [SerializeField] private float _roadBorders = 2.5f;

        [SerializeField] private Animator _animator;

        private float _oldMousePositionX;
        private float _rotationY;
    
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _oldMousePositionX = Input.mousePosition.x;
                _animator.SetBool(IsRunning, true);
            }
        
            if (Input.GetMouseButton(0))
            {
                Vector3 nextPosition = transform.position + transform.forward * _speed * Time.deltaTime;
                nextPosition.x = Mathf.Clamp(nextPosition.x, -_roadBorders, _roadBorders);
                transform.position = nextPosition;
        
                float deltaX = Input.mousePosition.x - _oldMousePositionX;
                _oldMousePositionX = Input.mousePosition.x;

                _rotationY += deltaX;
                _rotationY = Mathf.Clamp(_rotationY, -_limitRotationAngle, _limitRotationAngle);
                transform.eulerAngles = new Vector3(0, _rotationY, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _animator.SetBool(IsRunning, false);
            }
        }
    }
}