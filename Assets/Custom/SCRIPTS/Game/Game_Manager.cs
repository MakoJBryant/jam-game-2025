using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public new Audio audio;
    public InputActions controls;
    public Game_Data data;
    public Player player;
    public Transform startPoint;

    private void Awake()
    {
        instance = instance != null ? instance : this;
        controls ??= new InputActions();
        data ??= new Game_Data();
    }

    private void Start()
    {
        ResetPlayerPosition();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void OnDeath()
    {
        data.deathCount++;

        OnScaleReset();
        ResetPlayerPosition();

        audio.controller.PlayAudioClip(audio.library.deathSFX);
    }

    public void OnWin()
    {
        data.winCount++;

        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void OnCoinCollected()
    {
        data.coinsCollected++;
        player.particles.coinFX.Play();
        audio.controller.PlayAudioClip(audio.library.coinSFX);
    }

    public void OnFigCollected()
    {
        data.figsCollected++;
        player.particles.figBarFX.Play();
        audio.controller.PlayAudioClip(audio.library.figSFX);
    }

    public void OnGrow()
    {
        if (!player.sizeControl.CooldownActive && !player.sizeControl.ShouldGrow)
            audio.controller.PlayAudioClip(audio.library.growSFX);
        
        player.sizeControl.SetShouldGrow(true);
        player.sizeControl.SetShouldShrink(false);
        player.sizeControl.SetResetTimer(5);
        player.sizeControl.SetCooldownActive(true);
    }
    public void OnShrink()
    {
        if (!player.sizeControl.CooldownActive && !player.sizeControl.ShouldShrink)
            audio.controller.PlayAudioClip(audio.library.shrinkSFX);
        
        player.sizeControl.SetShouldGrow(false);
        player.sizeControl.SetShouldShrink(true);
        player.sizeControl.SetResetTimer(5);
        player.sizeControl.SetCooldownActive(true);
    }


    public void OnJump(int jumpForce, ForceMode2D forceMode)
    {
        audio.controller.PlayAudioClip(audio.library.jumpSFX);
        Game_Manager.instance.player.particles.dustFX.Play();
        player.rb.AddForceY(jumpForce, forceMode);
    }

    public void OnMovement(Vector2 input)
    {
        player.movement.InputMovement(input);
        player.face.InputMovement(input);
        if (player.movement.IsGrounded())
        {
            player.particles.dustFX.Play();
            audio.controller.PlayAudioClip(audio.library.moveSFX);
        }
    }

    public void OnScaleReset()
    {
        player.sizeControl.SetShouldGrow(false);
        player.sizeControl.SetShouldShrink(false);
        player.sizeControl.SetShouldResetScale(true);
        player.sizeControl.SetCooldownActive(false);

        audio.controller.PlayAudioClip(audio.library.resetSFX);
    }

    public void ResetPlayerPosition() => player.transform.position = startPoint.position;
}
