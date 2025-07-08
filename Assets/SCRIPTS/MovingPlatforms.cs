using System.Security.Cryptography;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    /*    public Transform posA, posB;
        public float speed;
        Vector3 targetPos;

        private void Start()
        {
            targetPos = posB.position;
        }

        private void Update()
        {
            if(Vector2.Distance(transform.position, posA.position) < 0.05f)
            {
                targetPos = posB.position;
            }
            else if(Vector2.Distance(transform.position, posB.position) < 0.05f)
            {
                targetPos = posA.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (GM.Instance.playerTransform)
            {
                collision.transform.parent = this.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (GM.Instance.playerTransform)
            {
                collision.transform.parent = null;
            }
        }*/
    enum MoveAxis { Horizontal = 0, Vertical = 1}
    enum MoveMethod { Axis = 0, transform = 1 }

    [SerializeField] private float axisDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private MoveMethod moveMethod;
    [SerializeField] private MoveAxis moveAxis;
    [SerializeField] private Transform targetTransform;

    Vector2 posA;
    Vector2 posB;
    Vector2 targetPos;

    private void Start()
    {
        CreateOscillationPoints();
        AssignValues();
    }

    private void Update()
    {
        MoveBetweenPoints();
    }

    private void AssignValues()
    {
        targetPos = posA;
    }

    private void CreateOscillationPoints()
    {
        if (moveMethod == MoveMethod.Axis) // Generates points on an axis at a set distance from the origin
        {
            posA = transform.position;
            Vector2 moveDirection;

            if (moveAxis == MoveAxis.Horizontal)
            {
                moveDirection = new(1, 0);
                posB = posA + axisDistance * moveDirection;
            }
            else if (moveAxis == MoveAxis.Vertical)
            {
                moveDirection = new(0, 1);
                posB = axisDistance * moveDirection;
            }
        }

        if (moveMethod == MoveMethod.transform) // Sets points to this transform's position and the position set in editor.
        {
            posA = transform.position;
            posB = targetTransform.position;
        }
    }

    private void MoveBetweenPoints()
    {
        if (Vector2.Distance(transform.position, posA) < 0.05f)
            targetPos = posB;
        else if (Vector2.Distance(transform.position, posB) < 0.05f)
            targetPos = posA;

        Vector2 moveDelta = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime) - (Vector2)transform.position;
        transform.Translate(moveDelta);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
