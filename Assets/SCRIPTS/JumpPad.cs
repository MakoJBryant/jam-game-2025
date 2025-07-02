using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Range(500, 2500)]
    [SerializeField] private int jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForceY(jumpForce, ForceMode2D.Force);
        }
    }
}
