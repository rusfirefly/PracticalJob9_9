
using UnityEngine;

public class InputHandlerExample : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            _enemy.Kill();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _enemy.StandUP();
        }
    }
}
