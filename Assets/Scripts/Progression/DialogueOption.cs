
using System;
using UnityEngine;
using Utility;

namespace Progression
{
    [Serializable]
    public struct DialogueOption
    {
        [SerializeField] private string text;
        [SerializeField] private bool triggersNextStage;
        [SerializeField] private NullableSerializable<Dialogue> followingDialogue;

        public string Text => text;
        public bool TriggersNextStage => triggersNextStage;
        public Dialogue? FollowingDialogue => followingDialogue;
        
    }
}
