using System;
using UnityEngine;


namespace Progression
{
    [Serializable] 
    public struct Dialogue
    {
        [SerializeField] [TextArea] private string mainText;

        [SerializeField] private DialogueOption[] options;

        public string MainText => mainText;
        public DialogueOption[] Options => options;
        
        
    }
}