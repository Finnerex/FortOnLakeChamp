using System;
using UnityEngine;

public class PickubableObject : MonoBehaviour, IInteractable
{

    [SerializeField] private Vector3 relativePosition;
    [SerializeField] private Quaternion rotation;
    private PlayerInteractController _player;
    private GameObject _head;
    
    public bool IsHeld { get; private set; }

    private Rigidbody _rigidbody;

    private void Start()
    {
        _player = FindObjectOfType<PlayerInteractController>();
        _rigidbody = GetComponent<Rigidbody>();
        _head = _player.GetComponentInChildren<Camera>().gameObject;
    }

    public bool OnInteract()
    {

        if (!ReferenceEquals(_player.HeldObject, null))
            return false;

        _player.HeldObject = this;
        _rigidbody.isKinematic = true;

        Transform objectTransform = transform;
        objectTransform.SetParent(_head.transform);

        objectTransform.localPosition = relativePosition;
        objectTransform.localRotation = rotation;

        IsHeld = true;

        return true;
    }

    public void Throw(Vector3 force)
    {
        _rigidbody.isKinematic = false;

        IsHeld = false;
        
        transform.SetParent(null);
        _player.HeldObject = null;
        
        _rigidbody.AddForce(force);
    }
    
    
}
