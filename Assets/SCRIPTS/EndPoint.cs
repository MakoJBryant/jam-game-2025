using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex + 1);
    }
}
