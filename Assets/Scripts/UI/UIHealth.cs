using UnityEngine;

namespace Rift
{
    class UIHealth : MonoBehaviour
    {
        private Health _health;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _health = GetComponentInParent<Health>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _health.onValueChanged += OnHealthValueChanged;
        }

        private void OnDisable()
        {
            _health.onValueChanged -= OnHealthValueChanged;
        }

        private void OnHealthValueChanged()
        {
            _rectTransform.anchorMax = new Vector2(_health.ratio, 1.0f);
        }
    }
}
