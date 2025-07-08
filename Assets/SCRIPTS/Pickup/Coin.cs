using System;
using UnityEngine;

public class Coin : MonoBehaviour, Collectible
{
    public ParticleSystem coinEffect;
    public static event Action OnCoinCollected;
    public void Collect()
    {
        coinEffect.Play();
        Debug.Log("you got coin");
        Destroy(gameObject);
        OnCoinCollected?.Invoke();
    }

}
