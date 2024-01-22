using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Audio
{
    [CreateAssetMenu(fileName = "New Rand Clip", menuName = "FOLC/Randomizable Audio Clip")]
    public class RandomizableAudioClip : ScriptableObject
    {
        // [SerializeField] public string name;
        [SerializeField] private AudioClip[] clips;
        private AudioSource[] _sources;
        
        [NonSerialized] public bool loop;
        private bool _isPlaying;
        private bool _randomizePitch;
        private int _currentClipIndex;

        private float _pitch;
        // public float Pitch
        // {
        //     get => _pitch;
        //     set
        //     {
        //         _pitch = value;
        //         foreach (AudioSource source in _sources)
        //         {
        //             source.pitch = value;
        //         }
        //     }
        // }

        public void Init(GameObject gameObject)
        {
            _sources = new AudioSource[clips.Length];

            for (int i = 0; i < clips.Length; i++)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = clips[i];
                source.playOnAwake = false;
                _sources[i] = source;
            }

        }

        public void Update() // fake update i guess
        {
            if (_isPlaying && loop && !_sources[_currentClipIndex].isPlaying)
            {
                Play(_randomizePitch);
            }

            if (!_sources[_currentClipIndex].isPlaying)
                _isPlaying = false;

        }

        public void Play(bool randomizePitch)
        {
            _randomizePitch = randomizePitch;
            _currentClipIndex = Random.Range(0, _sources.Length);
            _isPlaying = true;
            
            AudioSource source = _sources[_currentClipIndex];
            
            // float pitch = source.pitch;

            if (randomizePitch)
                source.pitch = Random.Range(0.9f, 1.1f);
            else
                source.pitch = 1;

            _sources[_currentClipIndex].Play();

            // source.pitch = pitch;

        }
        
        public void Stop()
        {
            _sources[_currentClipIndex].Stop();
        }


    }
}