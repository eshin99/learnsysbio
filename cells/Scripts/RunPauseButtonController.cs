using UnityEngine;
using UnityEngine.UI;

public class RunPauseButtonController : MonoBehaviour {

    bool paused;
    // Use this for initialization
    void Awake()
    {
        Time.timeScale = 0;
        paused = true;
    }

    public void ButtonClicked()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            GetComponentInChildren<Text>().text = "Pause";

        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            GetComponentInChildren<Text>().text = "Run";
        }
    }
}
