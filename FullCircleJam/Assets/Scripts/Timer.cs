
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float time = 0f;
    private bool timerRunning = true;

    void Awake()
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

    void Update()
    {
        if (timerRunning)
        {
            time += Time.deltaTime;
        }
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        time = 0f;
        timerRunning = true;
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
