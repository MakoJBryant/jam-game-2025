using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coin = collision.GetComponent<Coin>();
        if(coin)
        {
            coin.Collect();
        }

        var figBar = collision.GetComponent<Figbar>();
        if (figBar)
        {
            figBar.Collect();
        }
    }
}
