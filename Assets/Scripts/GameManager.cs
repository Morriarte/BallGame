using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _trackTime;
    private float _bestTrackTime;
    private bool _gameStarted;

    public float TrackTime => _trackTime;
    public float BestTrackTime => _bestTrackTime;

    public BallController ballController;

    private void Awake()
    {
        if (ballController == null)
            ballController = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
    }

    private void Start()
    {
        _bestTrackTime = GameData.Instance.LoadBestTrackTime();
    }

    private void Update()
    {
        if (_gameStarted)
        {
            _trackTime += Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        ballController.onTriggerEnter.AddListener(OnTriggerEnterMethod);
    }

    private void OnDisable()
    {
        ballController.onTriggerEnter.RemoveListener(OnTriggerEnterMethod);
    }


    private void OnTriggerEnterMethod(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            StartGame();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            FinishGame();
        }

        if (other.gameObject.CompareTag("DefeatZone"))
        {
            Defeat();
        }
    }

    private void StartGame()
    {
        _gameStarted = true;
        _trackTime = 0;
    }

    private void FinishGame()
    {
        _gameStarted = false;
        ballController.CanMove = false;

        if (_bestTrackTime > _trackTime)
        {
            _bestTrackTime = _trackTime;
            GameUI.Instance.ShowFinishMenu(true);
            GameData.Instance.SaveBestTrackTime(_bestTrackTime);
        }
        else
        {
            GameUI.Instance.ShowFinishMenu(true);
        }
    }

    private void Defeat()
    {
        _gameStarted = false;
        ballController.CanMove = false;
        GameUI.Instance.ShowFinishMenu(false);
    }
}
