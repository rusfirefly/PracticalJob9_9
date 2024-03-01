using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class EnemyView : MonoBehaviour
{

    public event Action StandUp;
    [SerializeField] private Text _name;
    private Animator _animator;
    private const string _isRuningKey= "IsRuning";
    private Transform _parent;
    private Transform _hipsBone;
    private Vector3 _hipsBoneDefaultPosition;


    public void Initialized(Transform parent)
    {
        _animator = GetComponent<Animator>();
        _parent = parent;
        _hipsBone = _animator.GetBoneTransform(HumanBodyBones.Hips);
        _hipsBoneDefaultPosition = _hipsBone.position;
    }

    public void EnableAnimator() => _animator.enabled = true;

    public void DisableAnimator() => _animator.enabled = false;

    public void StartRuning() => _animator.SetBool(_isRuningKey, true);

    public void StopRuning() => _animator.SetBool(_isRuningKey, false);

    public void ShowName() => _name.gameObject.SetActive(true);

    public void HideName() => _name.gameObject.SetActive(false);

    public void NewPositionParent()
    {
        _parent.position = _hipsBone.position;
        Ratation();
        CheckParentGround();
        _hipsBone.position = _hipsBoneDefaultPosition;
    }

    private void Ratation()
    {
        Vector3 hipsPosition = _hipsBone.position;
        Quaternion hipsRotation = _hipsBone.rotation;

        Vector3 directionForRotate = _hipsBone.up;

        if (IsFrontUp == true)
            directionForRotate *= -1;

        directionForRotate.y = 0;

        Quaternion correctionRotation = Quaternion.FromToRotation(_parent.forward, directionForRotate.normalized);
        _parent.rotation *= correctionRotation;

        _hipsBone.position = hipsPosition;
        _hipsBone.rotation = hipsRotation;
    }

    public void StandUpEvent() => StandUp?.Invoke();

    public void StartStandUpAnimation()
    {
        if (IsFrontUp)
        {
            _animator.Play("BackStandUp", -1, 0f);
        }
        else
        {
            _animator.Play("FrontStandUp", -1, 0f);
        }
    }

    private bool IsFrontUp => Vector3.Dot(_hipsBone.forward, Vector3.up) > 0;

    private void CheckParentGround()
    {
        bool isGround = Physics.Raycast(_parent.position, Vector3.down, out RaycastHit hit, 10f, 1 << LayerMask.NameToLayer("Ground"));
            
        if (isGround)
        {
           _parent.position = new Vector3(_parent.position.x, hit.point.y, _parent.position.z);
        }
    }

    public float DistanceToGround()
    {
        Vector3 ground = _hipsBone.position;
        ground.y = 0;
        return Vector3.Distance(_hipsBone.position, ground);
    }

    public bool IsGround()
    {
        return DistanceToGround() < 0.3f;
    }
}
