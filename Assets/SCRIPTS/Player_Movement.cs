using UnityEditor.ShaderGraph;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public ParticleSystem dustPlayer;

    [Range(1, 10)]
    [SerializeField] private float movementSpeed;
    [Range(1, 20)]
    [SerializeField] private int jumpForce;
    private bool canJump = true;

    private Rigidbody2D rb;
    private Vector3 movementDirection;

    private bool IsGrounded()
    {
        Transform parent = transform.parent;
        transform.SetParent(null);
        float yPos = transform.position.y - transform.localScale.y / 2 - .01f; // Places the raycast position just below the character
        Vector2 pos = new(transform.position.x, yPos);
        transform.parent = parent;
        return Physics2D.Raycast(pos, Vector2.down, .1f); // Checks if grounded
    }

    private void Start()
    {
        AssignComponents();
    }

    private void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime * movementDirection);
    }

    private void AssignComponents()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InputMovement(Vector2 input)
    {
        if(IsGrounded())
            DrawDust();
        movementDirection.x = input.x;
    }

    public void Jump()
    {
        if (IsGrounded() && canJump)
        {
            DrawDust();
            rb.AddForceY(jumpForce, ForceMode2D.Impulse); // Jump if true
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    void DrawDust()
    {
        dustPlayer.Play();
    }
}
