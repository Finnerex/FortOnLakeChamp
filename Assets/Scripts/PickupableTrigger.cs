using System.Linq;
using Progression;
using UnityEngine;
using Utility;

public class PickupableTrigger : PickubableObject
{
    
    private Triggerable[] _triggerables;

    private void Awake()
    {
        _triggerables = GetComponents<Triggerable>();
    }
    
    public override bool OnInteract()
    {
        if (!base.OnInteract())
            return false;
        
        foreach (Triggerable triggerable in _triggerables)
        {
            if (triggerable.Stages.Contains(StageManager.CurrentStage))
                triggerable.Trigger();
        }
        
        return true;

    }
}
