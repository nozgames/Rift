using System.Linq;
using NoZ;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rift
{
    class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform _cameraShake = null;

        private static GameManager _instance = null;

        private bool _gamepad = false;

        /// <summary>
        /// True if there is an active gamepad
        /// </summary>
        public static bool isUsingGamepad => _instance._gamepad;

        public static GameObject player { get; set; }

        public static int enemyCount { get; set; }

        private void Awake()
        {
            _instance = this;
            Initialize();
        }

        public void Initialize ()
        {
            _gamepad = InputSystem.devices.Where(d => d.enabled && d is Gamepad).Any();
            InputSystem.onDeviceChange += OnDeviceChanged;
        }

        public void Shutdown()
        {
            InputSystem.onDeviceChange -= OnDeviceChanged;
        }

        private void OnDeviceChanged(InputDevice inputDevice, InputDeviceChange deviceChange)
        {
            _gamepad = InputSystem.devices.Where(d => d.enabled && d is Gamepad).Any();
        }

        public static void ShakeCamera (float intensity, float duration)
        {
            Tween.Shake(new Vector2(intensity, intensity), intensity)
                .Duration(duration)
                .Key("shake")
                .Start(_instance._cameraShake.gameObject);
        }
    }

}
