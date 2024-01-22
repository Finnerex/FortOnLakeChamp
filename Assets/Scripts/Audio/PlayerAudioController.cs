using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Audio
{
    public class PlayerAudioController : MonoBehaviour
    {
        [SerializeField] private RandomizableAudioClip[] clips;
        private readonly Dictionary<string, RandomizableAudioClip> _sources = new();


        private void Awake()
        {
            foreach (RandomizableAudioClip clip in clips)
            {
                clip.Init(gameObject);
                _sources[clip.name] = clip;
            }
        }

        public void Play(string clipName, bool randomizePitch = false)
        {
            _sources[clipName].Play(randomizePitch);
        }

        public void Stop(string clipName)
        {
            _sources[clipName].Stop();
        }

        public void Loop(string clipName, bool loop)
        {
            _sources[clipName].loop = loop;
        }

        // public AudioSource GetSource(string clipName)
        // {
        //     return _sources[clipName];
        // }

        private void Update()
        {
            foreach (RandomizableAudioClip source in clips)
            {
                source.Update(); // this is dumb and i should probably find another way of doing it
            }
        }
    }
}