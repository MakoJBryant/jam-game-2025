using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM Instance;

    public Transform playerTransform;
    public Transform startPoint;

    private void Awake()
    {
        Instance = Instance != null ? Instance : this;
    }
}
