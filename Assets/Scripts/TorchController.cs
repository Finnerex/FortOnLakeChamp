using System.Transactions;
using UnityEngine;
using UnityEngine.Serialization;

public class TorchController : PickubableObject
{
    [SerializeField] private ParticleSystem flame;
    [SerializeField] private Light theLight;

    public override bool OnInteract()
    {
        flame.Play();
        theLight.enabled = true;
        return base.OnInteract();
    }

    public override void Throw(Vector3 force)
    {
        base.Throw(force);
        flame.Stop();
        theLight.enabled = false;
    }
}
