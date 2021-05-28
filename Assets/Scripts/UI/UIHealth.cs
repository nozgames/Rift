using NoZ;
using UnityEngine;

namespace Rift
{
    class UIHealth : ActorComponent
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        [ActorEventHandler]
        private void OnHealthChangedEvent(HealthChangedEvent evt)
        {
            _rectTransform.anchorMax = new Vector2(evt.health.ratio, 1.0f);
        }
    }
}
