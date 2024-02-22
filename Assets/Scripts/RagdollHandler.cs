using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    private List<Rigidbody> _rigbodies;

    public void Initialized()
    {
        _rigbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        Disable();
    }

    public void Enable()
    {
        foreach (Rigidbody rigbody in _rigbodies)
            rigbody.isKinematic = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rigbody in _rigbodies)
            rigbody.isKinematic = true;
    }

    public void Hit(Vector3 force, Vector3 hitPosiotion)
    {
        Rigidbody injuredRiginbode = _rigbodies.OrderBy(rigbody => Vector3.Distance(rigbody.position, hitPosiotion)).First();
        injuredRiginbode.AddForceAtPosition(force, hitPosiotion, ForceMode.Impulse);
    }
}
