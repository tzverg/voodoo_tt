using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text ScoreL;

    private static int scoreValue;
    private static bool changeScoreValue;

    void Awake()
    {
        scoreValue = 0;
        changeScoreValue = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        TimeController.paused = false;
    }
    public void ExitButton()
    {
        #if UNITY_ANDROID
        Application.Quit();
        #endif
    }

    public static void AddSoresNum(int scoreV)
    {
        scoreValue = scoreValue + scoreV;
        changeScoreValue = true;
    }

    private void Update()
    {
        if (changeScoreValue)
        {
            ScoreL.text = scoreValue.ToString();
            changeScoreValue = false;
        }
    }
}