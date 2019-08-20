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
    }
    public void ExitButton()
    {
        #if UNITY_ANDROID
        Application.Quit();
        #endif
    }

    public static void AddCoin()
    {
        scoreValue = ++scoreValue;
        changeScoreValue = true;
    }

    public static void AddSoresForGrapple()
    {
        scoreValue = scoreValue + 10;
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