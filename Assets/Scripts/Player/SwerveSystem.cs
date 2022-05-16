using UnityEngine;

namespace RedPanda
{
    public class SwerveSystem : MonoBehaviour
    {
        [Range(1f, 5f)][SerializeField] private float _forwardSpeed = 3.0f;
        [Range(0.1f, 0.75f)][SerializeField] private float _horizontalSpeed = 0.5f;
        [SerializeField] Rigidbody _body;
        private float _lastFrameFingerPositionX;
        private float _moveFactorX;
        public float MoveFactorX { get => _moveFactorX; private set => _moveFactorX = value; }
        public float ForwardSpeed { get => _forwardSpeed; set => _forwardSpeed = value; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                MoveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MoveFactorX = 0f;
            }
        }
        private void FixedUpdate()
        {
            _body.velocity = new Vector3(MoveFactorX * _horizontalSpeed, _body.velocity.y, ForwardSpeed); //* Time.fixedDeltaTime
        }
    }
}