using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject joystick;
    public GameObject scorePanel;

    private bool paused = true;

    #region Monobehaviour API

    private void Start()
    {
        SetTimeScale();
    }

    public void SwitchGameState()
    {
        paused = !paused;

        SetTimeScale();

        gameObject.SetActive(paused);
        joystick.SetActive(!paused);
        scorePanel.SetActive(!paused);
    }

    private void SetTimeScale()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    #endregion
}
