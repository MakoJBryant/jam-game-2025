using UnityEditor.ShaderGraph;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float movementSpeed;
    [Range(1, 20)]
    [SerializeField] private int jumpForce;

    private Rigidbody2D rb;
    private Vector3 movementDirection;

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
        movementDirection.x = input.x;
    }

    public void Jump()
    {
        float yPos = transform.position.y - transform.localScale.y / 2 - .01f; // Places the raycast position just below the character
        Vector2 pos = new(transform.position.x, yPos);
        if (Physics2D.Raycast(pos, Vector2.down, .1f)) // Checks if grounded
            rb.AddForceY(10, ForceMode2D.Impulse); // Jump if true
    }
}
