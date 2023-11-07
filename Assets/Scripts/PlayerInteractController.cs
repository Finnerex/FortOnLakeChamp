using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInteractController : MonoBehaviour
{

    private GameObject _camera;
    [SerializeField] private GameObject interactCrossHair;
    
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

        if (!Physics.Raycast(headTransform.position, headTransform.forward, out RaycastHit hitInfo, 5))
        {
            // Not pointing at anything
            interactCrossHair.SetActive(false);
            return;
        }

        // expensive method invocation can go suck mah bawls (it also shouldn't be that bad because of the prior check)
        IInteractable hitObject = hitInfo.collider.GetComponent<IInteractable>();

        if (hitObject == null)
        {
            // Not pointing at interactable
            interactCrossHair.SetActive(false);
            return;
        }

        interactCrossHair.SetActive(true);

        if (Input.GetMouseButton(0))
            hitObject.OnInteract();

        // apparently this is a thing which is cool (avoid null check)
        // hitObject?.OnInteract();

    }
}
