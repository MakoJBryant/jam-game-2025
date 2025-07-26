using UnityEngine;

public class Input_Controls : MonoBehaviour
{
    private void Start()
    {
        AssignInputEvents();
    }

    private void AssignInputEvents()
    {
        Game_Manager.instance.controls.Character.Move.performed += ctx => Game_Manager.instance.OnMovement(ctx.ReadValue<Vector2>());
        Game_Manager.instance.controls.Character.Move.canceled += ctx => Game_Manager.instance.OnMovement(Vector2.zero);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            Game_Manager.instance.player.movement.Jump();
    }
}
