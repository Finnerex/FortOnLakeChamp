using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Audio
{
    public class RandomizableAudioSource : MonoBehaviour // unnecessary??? could be done better??? maybe???
    {
        public RandomizableAudioClip clip;

        private void Awake()
        {
            clip.Init(gameObject);
        }

        private void Update()
        {
            clip.Update();
        }
    }
}