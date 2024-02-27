
using UnityEngine;

public class InputHandlerExample : MonoBehaviour
{
    [SerializeField] private Character _player;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _player.Attack();
        }
    }
}
