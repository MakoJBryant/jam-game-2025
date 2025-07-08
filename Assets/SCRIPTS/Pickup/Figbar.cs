using System;
using UnityEngine;

public class Figbar : MonoBehaviour, Collectible
{
    public ParticleSystem figbarEffect;
    public static event Action OnFigbarCollected;
    public void Collect()
    {
        figbarEffect.Play();
        Debug.Log("you got figbar");
        Destroy(gameObject);
        OnFigbarCollected?.Invoke();
    }
}
