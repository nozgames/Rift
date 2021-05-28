using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rift
{
    class GameManager : MonoBehaviour
    {
        private static GameManager _instance = null;

        private bool _gamepad = false;

        /// <summary>
        /// True if there is an active gamepad
        /// </summary>
        public static bool isUsingGamepad => _instance._gamepad;

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
    }

}
