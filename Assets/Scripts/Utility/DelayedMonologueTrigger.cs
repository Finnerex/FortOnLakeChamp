using System;
using UnityEngine;

namespace Utility
{
    public class DelayedMonologueTrigger : MonologueTrigger
    {

        [SerializeField] private float delayTimeSeconds;
        private float _delaySecondsLeft;

        private void Awake()
        {
            _delaySecondsLeft = delayTimeSeconds + 1;
        }

        public override void Trigger()
        {
            _delaySecondsLeft = delayTimeSeconds;
        }

        private void Update()
        {
            if (_delaySecondsLeft > 0 && _delaySecondsLeft <= delayTimeSeconds)
                _delaySecondsLeft -= Time.deltaTime;
            
            else if (_delaySecondsLeft <= 0)
            {
                _delaySecondsLeft = delayTimeSeconds + 1;
                base.Trigger();
            }
            
        }
    }
}