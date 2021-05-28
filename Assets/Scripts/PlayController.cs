using UnityEngine;
using UnityEngine.InputSystem;

namespace Rift
{
    public class PlayController : MonoBehaviour
    {
        [SerializeField] private InputActionReference _moveAction = null;
        [SerializeField] private InputActionReference _lookAction = null;
        [SerializeField] private InputActionReference _mouseLookAction = null;
        [SerializeField] private InputActionReference _primaryAttackAction = null;
        [SerializeField] private float _speed = 10.0f;

        [SerializeField] private GameObject _primaryAttackProjectile = null;

        private void Awake()
        {
            _primaryAttackAction.action.performed += OnPrimaryAttack;
        }

        private void OnPrimaryAttack (InputAction.CallbackContext ctx)
        {
            var projectile = Instantiate(_primaryAttackProjectile, null).GetComponent<Projectile>();
            projectile.transform.position = transform.position + transform.forward * 0.5f;
            projectile.transform.rotation = transform.rotation;
        }

        private void OnEnable()
        {
            _moveAction.action.Enable();
            _mouseLookAction.action.Enable();
            _primaryAttackAction.action.Enable();
        }

        private void OnDisable()
        {
            _moveAction.action.Disable();
            _mouseLookAction.action.Disable();
            _primaryAttackAction.action.Disable();
        }

        private void FixedUpdate()
        {
            var cameraRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            var move = _moveAction.action.ReadValue<Vector2>();
            transform.position += cameraRotation * move.ToVector3XZ() * _speed * Time.deltaTime;

            if(GameManager.isUsingGamepad)
            {

            }
            else
            {
                var position = _mouseLookAction.action.ReadValue<Vector2>();
                var normalizedPosition = new Vector2(
                    position.x - (Screen.width * 0.5f), 
                    position.y - (Screen.height * 0.5f)).normalized.ToVector3XZ();

                transform.localRotation = cameraRotation * Quaternion.LookRotation(normalizedPosition);
            }
        }
    }
}
