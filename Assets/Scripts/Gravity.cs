using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody[] _objects;

    private void OnTriggerEnter(Collider other)
    {
        _objects = GetObjects();
        OffGravity(_objects);
    }

    private void OnTriggerExit(Collider other)
    {
        OnGravity(_objects);
    }

    private Rigidbody[] GetObjects() => FindObjectsOfType<Rigidbody>();

    private void OnGravity(Rigidbody[] objects)
    {
        foreach (Rigidbody obj in objects)
            obj.useGravity = true;
    }
    
    private void OffGravity(Rigidbody[] objects)
    {
        foreach (Rigidbody obj in objects)
            obj.useGravity = false;
    }
}
