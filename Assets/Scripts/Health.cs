﻿using NoZ;
using UnityEngine;

namespace Rift
{
    class Health : ActorComponent
    {
        [SerializeField] private float _max = 100.0f;

        private float _value;

        public float value => _value;

        public float ratio => _value / _max;

        private void Awake()
        {
            _value = _max;
        }

        public void Adjust (float amount)
        {
            var oldValue = _value;
            _value += amount;
            _value = Mathf.Clamp(_value, 0.0f, _max);

            if(oldValue != _value)
                Send(new HealthChangedEvent(this, oldValue - _value));
        }
    }
}
