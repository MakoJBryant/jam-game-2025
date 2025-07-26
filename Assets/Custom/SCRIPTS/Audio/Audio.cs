using UnityEngine;

public class Audio : MonoBehaviour
{
    public Audio_Controller controller;
    public Audio_Library library;

    private void Start()
    {
        controller = GetComponent<Audio_Controller>();
        library = GetComponent<Audio_Library>();
    }
}
