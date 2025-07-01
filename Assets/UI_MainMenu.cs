using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
