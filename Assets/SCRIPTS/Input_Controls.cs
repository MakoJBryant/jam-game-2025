using UnityEngine;

public class Input_Controls : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        AssignComponents();
        AssignInputEvents();
    }

    private void AssignComponents()
    {
        player = GetComponent<Player>();
    }

    private void AssignInputEvents()
    {
        player.controls.Character.Move.performed += ctx => player.movement.InputMovement(ctx.ReadValue<Vector2>());
        player.controls.Character.Move.canceled += ctx => player.movement.InputMovement(Vector2.zero);

        player.controls.Character.Jump.performed += ctx => player.movement.Jump();
    }
}
