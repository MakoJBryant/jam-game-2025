using UnityEngine;

public class Player_Collisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                Game_Manager.instance.OnCoinCollected();
                Destroy(other.gameObject);
                break;

            case "Figbar":
                Game_Manager.instance.OnFigCollected();
                Destroy(other.gameObject);
                break;

            case "EndPoint":
                Game_Manager.instance.OnWin();
                break;

            case "JumpPad":
                int jumpForce = Game_Manager.instance.data.jumpPadForce;
                Game_Manager.instance.OnJump(jumpForce, ForceMode2D.Force);
                break;

            case "GrowPad":
                Game_Manager.instance.OnGrow();
                break;

            case "ShrinkPad":
                Game_Manager.instance.OnShrink();
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "JumpPad":
                int jumpForce = Game_Manager.instance.data.jumpPadForce;
                Game_Manager.instance.OnJump(jumpForce, ForceMode2D.Force);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Game_Manager.instance.player.movement.IsGrounded())
            Game_Manager.instance.player.movement.CanJump(true);

        switch (collision.gameObject.tag)
        {
            case "KillZone":
                Game_Manager.instance.OnDeath();
                break;

            case "MovingPlatform":
                //if (!Game_Manager.instance.player.sizeControl.ShouldResetScale)
                transform.SetParent(collision.transform);
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "MovingPlatform":
                //if (!Game_Manager.instance.player.sizeControl.ShouldResetScale)
                transform.SetParent(null);
                break;
        }
    }
}
