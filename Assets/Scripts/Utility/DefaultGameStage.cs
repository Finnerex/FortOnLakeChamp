using System;
using Progression;
using UnityEngine;

namespace Utility
{
    public class DefaultGameStage : MonoBehaviour
    {
        [SerializeField] private GameStage stage;

        private void Awake()
        {
            StageManager.CurrentStage = stage;
        }
    }
}