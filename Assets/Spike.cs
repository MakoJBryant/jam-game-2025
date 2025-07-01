using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GM.Instance.playerTransform.position = GM.Instance.startPoint.position;
    }
}
