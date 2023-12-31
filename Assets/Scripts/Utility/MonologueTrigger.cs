﻿using System.Linq;
using Player;
using Progression;
using UnityEngine;

namespace Utility
{
    public class MonologueTrigger : MonoBehaviour
    {

        [TextArea] [SerializeField] private string text;
        [SerializeField] private GameStage[] stages;
        [SerializeField] private float displayTimeSeconds = 5;
        
        [SerializeField] private PlayerSpeech speechController;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!stages.Contains(StageManager.CurrentStage) || other.GetComponent<PlayerController>() == null)
                return;
        
            speechController.SetMonologue(text, displayTimeSeconds);
        }
    }
}
