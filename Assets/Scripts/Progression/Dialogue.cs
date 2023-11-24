using System;
using UnityEngine;


namespace Progression
{
    [Serializable]
    public class Dialogue
    {
        [SerializeField] private string mainText;

        [SerializeField] private string[] options = { "..." };
        [SerializeField] private Dialogue[] followingDialogues;

        public string MainText => mainText;
        public string[] Options => options;
        public Dialogue[] FollowingDialogues => followingDialogues;
        
    }
}