using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Range(500, 2500)]
    [SerializeField] private int jumpForce;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GM.Instance.playerTransform.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.AddForceY(jumpForce, ForceMode2D.Force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rb.AddForceY(jumpForce, ForceMode2D.Force);
    }
}
