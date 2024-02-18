using System.Linq;
using Progression;
using UnityEngine;

namespace Utility
{
    public class ToggleObjectTrigger : MonoBehaviour
    {
        [SerializeField] private GameStage[] stages;
        [SerializeField] private GameObject toToggle;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!stages.Contains(StageManager.CurrentStage) || other.GetComponent<PlayerController>() == null)
                return;

            toToggle.SetActive(!toToggle.activeSelf);

        }
    }
}