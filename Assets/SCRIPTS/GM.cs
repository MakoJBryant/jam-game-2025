using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM Instance;

    public Transform playerTransform;
    public Transform startPoint;

    public int deathCount = 0;
    public int winCount = 0;
    public int coinsCollected = 0;
    public int figsCollected = 0;

    private void Awake()
    {
        Instance = Instance != null ? Instance : this;
    }

    public void HandleDeath()
    {
        deathCount++;
        playerTransform.position = startPoint.position;
    }

    public void HandleWin()
    {
        winCount++;
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void HandleCoinCollected()
    {
        coinsCollected++;
        // Handle collection
    }

    public void HandleFigCollected()
    {
        figsCollected++;
        // Handle collection;
    }
}
