using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player_Face : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> eyes;

    private readonly float maxDistanceFromOrigin = .15f;
    private Vector2 movementDirection = new();

    public void InputMovement(Vector2 input) => movementDirection = input;

    private void Update()
    {
        foreach (Transform eye in eyes)
        {
            Vector2 direction = movementDirection * maxDistanceFromOrigin;
            eye.localPosition = Vector2.Lerp(eye.localPosition, direction, moveSpeed * Time.deltaTime);
        }
    }
}
