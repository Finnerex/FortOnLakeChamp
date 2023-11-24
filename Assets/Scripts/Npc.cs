using System;
using System.Collections.Generic;
using Progression;
using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{

    [SerializeField] private PlayerSpeech speechController;
    [SerializeField] private PlayerCamera playerCamera;
    
    [SerializeField] private Dialogue[] dialogues;
    [SerializeField] private GameStage[] correspondingStages; // just please let me serialize a dictionary
    
    private Dictionary<GameStage, Dialogue> _dialogues;

    private void Awake()
    {
        _dialogues = new Dictionary<GameStage, Dialogue>();

        for (int i = 0; i < dialogues.Length; i++)
        {
            _dialogues.Add(correspondingStages[i], dialogues[i]);
        }
    }

    public bool OnInteract()
    {
        Dialogue dialogue = _dialogues[StageManager.CurrentStage];

        if (dialogue == null)
            return false;

        playerCamera.LookAt(transform.position, 1);
        speechController.SetDialogue(dialogue);
        
        return true;
    }
}
