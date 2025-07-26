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

        winsText.text = Game_Manager.instance.data.winCount.ToString();
        deathsText.text = Game_Manager.instance.data.deathCount.ToString();
        figCountText.text = Game_Manager.instance.data.figsCollected.ToString();
        coinCountText.text = Game_Manager.instance.data.coinsCollected.ToString();
    }
}
