
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text finalTimeText;

    void Start()
    {
        if (Timer.Instance != null)
        {
            Timer.Instance.StopTimer();
            finalTimeText.text = Timer.Instance.GetFormattedTime();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
