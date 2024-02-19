using System;
using System.Linq;
using Audio;
using Progression;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility
{
    // Probably change this to use a randomizable
    public class SoundTrigger : Triggerable
    {
        [SerializeField] private RandomizableAudioSource[] sources;
        [SerializeField] private bool randomizePitch;
        [SerializeField] private float cooldownTimeSeconds;
        private float _cooldownSecondsRemaining;
        

        public override void Trigger()
        {
            if (_cooldownSecondsRemaining > 0)
                return;

            sources[Random.Range(0, sources.Length)].clip.Play(randomizePitch);

            _cooldownSecondsRemaining = cooldownTimeSeconds;

        }

        private void Update()
        {
            if (_cooldownSecondsRemaining > 0) 
                _cooldownSecondsRemaining -= Time.deltaTime;
        }
    }
}