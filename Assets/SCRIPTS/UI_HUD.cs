using TMPro;
using UnityEngine;

public class UI_HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text winsText;
    [SerializeField] private TMP_Text deathsText;
    [SerializeField] private TMP_Text figCountText;
    [SerializeField] private TMP_Text coinCountText;

    private void Update()
    {
        timeText.text = Time.timeSinceLevelLoad.ToString();

        winsText.text = GM.Instance.winCount.ToString();
        deathsText.text = GM.Instance.deathCount.ToString();
        figCountText.text = GM.Instance.figsCollected.ToString();
        coinCountText.text = GM.Instance.coinsCollected.ToString();
    }
}
