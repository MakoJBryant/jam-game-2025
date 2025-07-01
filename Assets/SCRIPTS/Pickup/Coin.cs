using System;
using UnityEngine;

public class Coin : MonoBehaviour, Collectible
{
    public static event Action OnCoinCollected;
    public void Collect()
    {
        Debug.Log("you got coin");
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
    }

}
