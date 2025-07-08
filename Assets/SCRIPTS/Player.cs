using UnityEngine;

public class Player : MonoBehaviour
{
    public InputActions controls;
    public Player_Movement movement;
    public Animator animator;

    private void Awake()
    {
        controls ??= new InputActions();
        movement = GetComponent<Player_Movement>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
