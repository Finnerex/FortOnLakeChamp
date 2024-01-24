using System.Transactions;
using UnityEngine;

public class TorchController : PickubableObject
{
    [SerializeField] private ParticleSystem flame;

    public override bool OnInteract()
    {
        flame.Play();
        return base.OnInteract();
    }

    public override void Throw(Vector3 force)
    {
        base.Throw(force);
        flame.Stop();
    }
}
