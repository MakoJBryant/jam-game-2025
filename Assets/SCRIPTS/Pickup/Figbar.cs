using System;
using UnityEngine;

public class Figbar : MonoBehaviour, Collectible
{
    public static event Action OnFigbarCollected;
    public void Collect()
    {
        Debug.Log("you got figbar");
        Destroy(gameObject);
        OnFigbarCollected?.Invoke();
    }
}
