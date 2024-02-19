using System.Linq;
using Player;
using Progression;
using UnityEngine;

namespace Utility
{
    public class MonologueTrigger : Triggerable
    {

        [TextArea] [SerializeField] private string text;
        [SerializeField] private float displayTimeSeconds = 5;
        
        [SerializeField] private PlayerSpeech speechController;

        public override void Trigger()
        {
            speechController.SetMonologue(text, displayTimeSeconds);
        }
    }
}
