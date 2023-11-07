using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInteractController : MonoBehaviour
{

    private GameObject _camera;
    
    [SerializeField] private GameObject interactCrossHair;
    [SerializeField] private float throwSpeed;
    [SerializeField] private float dropSpeed; 
    
    private Collider _lastPointedAtObject;
    private IInteractable _lastInteractable;

    [NonSerialized] public PickubableObject HeldObject;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponentInChildren<Camera>().gameObject;
        interactCrossHair.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        Transform headTransform = _camera.transform;
        
        // throwing
        if (Input.GetKeyDown(KeyCode.F) && !ReferenceEquals(HeldObject, null))
            HeldObject.Throw(headTransform.forward * dropSpeed);
        else if (Input.GetKeyDown(KeyCode.G) && !ReferenceEquals(HeldObject, null))
            HeldObject.Throw(headTransform.forward * throwSpeed);

        // interacting / picking up
        
        if (!Physics.Raycast(headTransform.position, headTransform.forward, out RaycastHit hitInfo, 3))
        {
            // Not pointing at anything
            interactCrossHair.SetActive(false);
            return;
        }

        // this so that i dont call get component as often
        Collider hitObject = hitInfo.collider;

        IInteractable hitInteractable;

        if (hitObject == _lastPointedAtObject) // pointing at the same object
        {
            hitInteractable = _lastInteractable;
        }
        else // pointing at a new object
        {
            _lastPointedAtObject = hitObject;
            // expensive method invocation can go suck mah bawls (it also shouldn't be that bad because of the prior check)
            hitInteractable = hitObject.GetComponent<IInteractable>();
            _lastInteractable = hitInteractable;
        }

        if (hitInteractable == null)
        {
            // Not pointing at interactable
            interactCrossHair.SetActive(false);
            return;
        }

        interactCrossHair.SetActive(true);

        if (Input.GetMouseButton(0))
            hitInteractable.OnInteract();

        // apparently this is a thing which is cool (avoid null check)
        // hitObject?.OnInteract();

    }
}
