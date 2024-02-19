using System;
using System.Collections.Generic;
using Player;
using Progression;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;
using Quaternion = System.Numerics.Quaternion;

public class Npc : MonoBehaviour, IInteractable
{

    [SerializeField] private PlayerSpeech speechController;
    [SerializeField] private PlayerCamera playerCamera;
    
    [SerializeField] private Dialogue[] dialogues;
    [SerializeField] private GameStage[] correspondingStages; // just please let me serialize a dictionary
    
    private Dictionary<GameStage, Dialogue> _dialogues;

    [SerializeField] private Transform headTransform;
    [SerializeField] private float heightOffset;
    [SerializeField] private bool invertLook;

    private TriggerTriggerer _triggerer;

    private void Awake()
    {
        _dialogues = new Dictionary<GameStage, Dialogue>();

        for (int i = 0; i < dialogues.Length; i++)
        {
            _dialogues.Add(correspondingStages[i], dialogues[i]);
        }

        // headTransform = transform;
        _triggerer = GetComponent<TriggerTriggerer>();
    }

    private void Update()
    {
        Vector3 position = headTransform.position;
        
        if (invertLook)
            headTransform.LookAt(position - (playerCamera.transform.position - position));
        else
            headTransform.LookAt(playerCamera.transform.position);
        
        
    }

    public bool OnInteract()
    {
        if (!_dialogues.TryGetValue(StageManager.CurrentStage, out Dialogue dialogue))
            return false;

        playerCamera.LookAt(transform.position + Vector3.up * heightOffset, 1);
        speechController.SetDialogue(dialogue, gameObject.name, _triggerer);
        
        return true;
    }
    
}
