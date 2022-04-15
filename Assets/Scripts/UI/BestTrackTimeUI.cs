using UnityEngine;
using TMPro;

public class BestTrackTimeUI : MonoBehaviour
{
    public TextMeshProUGUI bestTrackTimeTextUI;

    private void Start()
    {
        var bestTrackTime = GameData.Instance.LoadBestTrackTime();

        if (bestTrackTime == int.MaxValue)
        {
            bestTrackTimeTextUI.text = "нет";
        }
        else
        {
            bestTrackTimeTextUI.text = bestTrackTime.ToString("f2");
        }
    }
}
