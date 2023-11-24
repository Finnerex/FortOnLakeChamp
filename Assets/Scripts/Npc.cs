using System;
using System.Collections.Generic;
using Progression;
using UnityEditor;
using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{

    [SerializeField] private PlayerSpeech speechController;
    [SerializeField] private PlayerCamera playerCamera;
    
    [SerializeField] private Dialogue[] dialogues;
    [SerializeField] private GameStage[] correspondingStages; // just please let me serialize a dictionary
    
    private Dictionary<GameStage, Dialogue> _dialogues;

    private Transform _transform;

    private void Awake()
    {
        _dialogues = new Dictionary<GameStage, Dialogue>();

        for (int i = 0; i < dialogues.Length; i++)
        {
            _dialogues.Add(correspondingStages[i], dialogues[i]);
        }

        _transform = transform;
    }

    private void Update()
    {
        _transform.LookAt(playerCamera.transform);
    }

    public bool OnInteract()
    {
        if (!_dialogues.TryGetValue(StageManager.CurrentStage, out Dialogue dialogue))
            return false;

        playerCamera.LookAt(transform.position, 1);
        speechController.SetDialogue(dialogue, gameObject.name);
        
        return true;
    }
    
}
