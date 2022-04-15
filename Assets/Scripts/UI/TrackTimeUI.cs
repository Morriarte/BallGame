using UnityEngine;
using TMPro;

public class TrackTimeUI : MonoBehaviour
{
    public TextMeshProUGUI trackTimeTextUI;
    public GameManager gameManager;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }
    }

    private void Update()
    {
        trackTimeTextUI.text = gameManager.TrackTime.ToString("f2");
    }
}
