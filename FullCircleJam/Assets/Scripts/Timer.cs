using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{

    public float time = 60f;
    public TextMeshProUGUI timerText;
    public bool gameEnded = false;
   

    // Update is called once per frame
    void Update()
{
    if (!gameEnded)
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            EndGame();
        }

        timerText.text = Mathf.Floor(time).ToString();
    }
}

    void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("EndScene");
    }

}
