
using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Progression
{
    [Serializable]
    public struct DialogueOption
    {
        [TextArea] [SerializeField] private string text;
        [SerializeField] private bool trigger;
        [SerializeField] [CanBeNull] private Dialogue followingDialogue;

        public string Text => text;
        public bool Trigger => trigger;
        [CanBeNull] public Dialogue FollowingDialogue => followingDialogue;
        
    }
    
}
