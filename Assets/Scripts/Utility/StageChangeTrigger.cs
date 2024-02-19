using Progression;
using UnityEngine;

namespace Utility
{
    public class StageChangeTrigger : Triggerable
    {
        [SerializeField] private GameStage nextStage; // do this or just have it increment?
        
        public override void Trigger()
        {
            StageManager.CurrentStage = nextStage;
        }
    }
}