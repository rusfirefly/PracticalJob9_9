using UnityEngine;

public class InputHandlerExample : MonoBehaviour
{
    [SerializeField] private Character _player;
    private const int _mouseLeftClick = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(_mouseLeftClick))
        {
            _player.Attack();
        }
    }
}
