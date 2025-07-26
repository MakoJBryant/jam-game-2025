using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Player_Face face;
    [HideInInspector] public Player_Movement movement;
    [HideInInspector] public Player_Particles particles;
    [HideInInspector] public Player_SizeControl sizeControl;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        face = GetComponentInChildren<Player_Face>();
        movement = GetComponent<Player_Movement>();
        particles = GetComponent<Player_Particles>();
        sizeControl = GetComponent<Player_SizeControl>();
        rb = GetComponent<Rigidbody2D>();
    }
}
