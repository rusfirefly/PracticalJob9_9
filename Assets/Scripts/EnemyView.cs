using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{
    private Animator _animator;
    private const string _isRuningKey= "IsRuning";
    private Transform _parent;
    private Transform _hipsBone;

    public void Initialized(Transform parent)
    {
        _animator = GetComponent<Animator>();
        _parent = parent;
        _hipsBone = _animator.GetBoneTransform(HumanBodyBones.Hips);
    }

    public void EnableAnimator() => _animator.enabled = true;

    public void DisableAnimator() => _animator.enabled = false;

    public void StartRuning() => _animator.SetBool(_isRuningKey, true);

    public void StopRuning() => _animator.SetBool(_isRuningKey, false);


    public void NewPositionParent()
    {
        _parent.position = _hipsBone.position;

        Ratation();

        //return _parent.position;
    }

    private void Ratation()
    {
        Vector3 hipsPosition = _hipsBone.position;
        Quaternion hipsRotation = _hipsBone.rotation;

        Vector3 directionForRotate = -_hipsBone.up;
        directionForRotate.y = 0;

        Quaternion correctionRotation = Quaternion.FromToRotation(_parent.forward, directionForRotate.normalized);
        _parent.rotation *= correctionRotation;

        _hipsBone.position = hipsPosition;
        _hipsBone.rotation = hipsRotation;

    }

}
