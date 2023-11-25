using UnityEngine;

namespace Progression
{
    public class StageChangeTrigger : MonoBehaviour
    {
        [SerializeField] private GameStage currentStage;
        [SerializeField] private GameStage nextStage; // do this or just have it increment?
        
        private void OnTriggerEnter(Collider other)
        {
            if (StageManager.CurrentStage != currentStage || other.GetComponent<PlayerController>() == null)
                return;

            StageManager.CurrentStage = nextStage;
        }
    }
}