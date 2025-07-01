using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void Start()
    {
        GM.Instance.playerTransform.position = transform.position;
    }
}
