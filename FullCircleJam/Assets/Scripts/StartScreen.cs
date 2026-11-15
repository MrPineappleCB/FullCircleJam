
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        if (Timer.Instance != null)
        {
            Timer.Instance.ResetTimer();
        }

        SceneManager.LoadScene("SampleScene");
    }

}
