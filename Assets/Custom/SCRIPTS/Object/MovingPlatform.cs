using System.Security.Cryptography;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private enum MoveAxis { Horizontal = 0, Vertical = 1}
    private enum MoveMethod { Axis = 0, transform = 1 }

    [SerializeField] private float axisDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private MoveMethod moveMethod;
    [SerializeField] private MoveAxis moveAxis;
    [SerializeField] private Transform targetTransform;

    private Vector2 posA;
    private Vector2 posB;
    private Vector2 targetPos;

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
        posA = transform.position;

        if (moveMethod == MoveMethod.Axis) // Generates posB on an axis at a set distance from the origin
        {
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

        if (moveMethod == MoveMethod.transform)
            posB = targetTransform.position;
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
}
