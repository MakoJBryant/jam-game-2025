using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private float xClampDistance = 0;
    [Range(0, 5)]
    [SerializeField] private float yClampDistance = 0;
    [Range(0, 5)]
    [SerializeField] private float lerpSpeed = 3;
    [Range(-5, 5)]
    [SerializeField] private float yOffset = 0;

    private void Update()
    {
        Vector3 playerPos = GM.Instance.playerTransform.position;
        if (Mathf.Abs(transform.position.x - playerPos.x) > xClampDistance) // Clamps camera movement
        {
            Vector3 newPos = transform.position;
            newPos.x = Mathf.Lerp(transform.position.x, playerPos.x, lerpSpeed * Time.deltaTime);
            transform.position = newPos;
        }

        float yPos = transform.position.y - yOffset; // Cancels offset for calculations
        if (Mathf.Abs(yPos - playerPos.y) > yClampDistance)
        {
            Vector3 newPos = transform.position;
            newPos.y = Mathf.Lerp(yPos, playerPos.y, lerpSpeed * Time.deltaTime);
            if (newPos.y < 0) // Makes camera not go below offset/0
                newPos.y = 0;
            newPos.y += yOffset; // Add offset
            transform.position = newPos;
        }

    }
}
