using UnityEngine;

public class Market_Manager : MonoBehaviour
{
    int stop;
    public GameObject WAITINGPAGE;
    // Update is called once per frame
    void Update()
    {
        Stop();
    }
    void Stop()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stop == 0)
            {
                stop = 1;
                Time.timeScale = 0;
                WAITINGPAGE.SetActive(true);
            }
            else if (stop == 1)
            {
                stop = 0;
                Time.timeScale = 1;
                WAITINGPAGE.SetActive(false);
            }
        }
        else
        {
            if (Time.timeScale == 1)
            {
                stop = 0;
            }
        }
    }
}
