using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private float clampDistance;
    [Range(0, 5)]
    [SerializeField] private float lerpSpeed;

    private void Update()
    {
        if (Vector2.Distance(transform.position, GM.Instance.playerTransform.position) > clampDistance)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Vector3.Lerp(transform.position, GM.Instance.playerTransform.position, lerpSpeed * Time.deltaTime).x;
            transform.position = newPosition;
        }
    }
}
