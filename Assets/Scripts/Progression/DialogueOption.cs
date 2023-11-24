
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Progression
{
    [Serializable]
    public struct DialogueOption
    {
        [TextArea] [SerializeField] private string text;
        [SerializeField] private bool triggersNextStage;
        [SerializeField] [CanBeNull] private Dialogue followingDialogue;

        public string Text => text;
        public bool TriggersNextStage => triggersNextStage;
        [CanBeNull] public Dialogue FollowingDialogue => followingDialogue;
        
    }
    
}
