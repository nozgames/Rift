using NoZ;
using UnityEngine;

namespace Rift
{
    class FadeOutAndDestroy : MonoBehaviour
    {
        [SerializeField] private float _delay = 1.0f;
        [SerializeField] private float _duration = 1.0f;

        private void OnEnable()
        {
#if true
            Tween.Fade(1.0f, 0.0f)
                .Delay(_delay)
                .Duration(_duration)
                .AutoDestroy()
                .Start(gameObject);
#endif
        }
    }
}
