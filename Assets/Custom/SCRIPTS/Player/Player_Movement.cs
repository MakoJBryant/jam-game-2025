using UnityEditor.ShaderGraph;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float movementSpeed;
    [Range(1, 20)]
    [SerializeField] private int jumpForce;

    private bool canJump = true;
    private Vector2 movementDirection;

    public Vector2 MovementDirection => movementDirection;

    public bool IsGrounded()
    {
        float yPos = transform.position.y - transform.localScale.y / 2 - .01f; // Places the raycast position just below the character
        Vector2 pos = new(transform.position.x, yPos);
        return Physics2D.Raycast(pos, Vector2.down, .1f); // Checks if grounded
    }

    public void CanJump(bool b) => canJump = b;
    public void InputMovement(Vector2 input) => movementDirection.x = input.x;


    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer() => transform.Translate(movementSpeed * Time.deltaTime * movementDirection);

    public void Jump()
    {
        if (IsGrounded() && canJump)
        {
            Game_Manager.instance.OnJump(jumpForce, ForceMode2D.Impulse);
            CanJump(false);
        }
    }
}
