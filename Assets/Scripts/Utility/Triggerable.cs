using Progression;
using UnityEngine;

namespace Utility
{
    public abstract class Triggerable : MonoBehaviour
    {
        [SerializeField] private GameStage[] stages;
        public GameStage[] Stages => stages;

        public abstract void Trigger();
    } 
}