using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadBestTrackTime();
    }

    public float LoadBestTrackTime()
    {
        return PlayerPrefs.GetFloat("bestTrackTime", int.MaxValue);
    }

    public void SaveBestTrackTime(float time)
    {
        PlayerPrefs.SetFloat("bestTrackTime", time);
    }
}
