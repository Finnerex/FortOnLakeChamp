using System;
using UnityEngine;

public class PickubableObject : MonoBehaviour, IInteractable
{

    [SerializeField] private Vector3 relativePosition;
    [SerializeField] private Quaternion rotation;
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;
    }

    public bool OnInteract()
    {
        
        Transform objectTransform = transform;
        objectTransform.SetParent(_player.transform);

        objectTransform.localPosition = relativePosition;
        objectTransform.localRotation = rotation;
        
        return true;
    }
    
    
}
