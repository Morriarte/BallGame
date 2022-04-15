using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }

    public GameManager gameManager;

    public GameObject finishPanel;
    public TextMeshProUGUI finishText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        finishPanel.SetActive(false);
    }

    public void ShowFinishMenu(bool win)
    {
        if (finishPanel.activeSelf) return;

        finishPanel.SetActive(true);
        if (win)
        {
            scoreText.gameObject.SetActive(true);
            finishText.text = "Вы победили!";
            finishText.color = Color.green;
        }
        else
        {
            scoreText.gameObject.SetActive(false);
            finishText.text = "Вы проиграли!";
            finishText.color = Color.red;
        }
        scoreText.text = gameManager.TrackTime.ToString("f2");
    }
}
