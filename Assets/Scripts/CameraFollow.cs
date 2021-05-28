using UnityEngine;

namespace Rift
{
    class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target = null;
        [SerializeField] private float _smoothTime = 1.0f;

        [Range(0.1f, 100.0f)]
        [SerializeField] private float _zoom = 1.0f;

        [Range(0.0f, 90.0f)]
        [SerializeField] private float _pitch = 70.0f;

        [Range(0.0f, 360.0f)]
        [SerializeField] private float _yaw = 45.0f;

        private Camera _camera;
        private Vector3 _positionVelocity;
        private Vector3 _rotationVelocity;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            transform.position = Frame();
            transform.localRotation = Quaternion.Euler(_pitch, _yaw, 0);
        }

        private void FixedUpdate()
        {
            if (null == _target)
                return;

            transform.position = Vector3.SmoothDamp(transform.position, Frame(), ref _positionVelocity, _smoothTime);
            transform.localRotation = Quaternion.Euler(Vector3.SmoothDamp(transform.localRotation.eulerAngles, new Vector3(_pitch, _yaw, 0), ref _rotationVelocity, _smoothTime));
        }

        private Vector3 Frame()
        {
            var distance = (_zoom * 0.5f) / Mathf.Tan(_camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            return
                // Target position
                _target.position

                // Zoom to frame entire target
                + (distance * -(Quaternion.Euler(_pitch, _yaw, 0) * Vector3.forward));
        }
    }
}
