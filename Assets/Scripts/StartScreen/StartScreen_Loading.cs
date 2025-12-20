using UnityEngine;

public class StartScreen_Loading : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        int start = PlayerPrefs.GetInt("Start",0);
        if (start == 0)
        {
            this.gameObject.SetActive(false);
        }
        else if (start == 1)
        {
            PlayerPrefs.SetInt("Start", 0);
        }
    }
}
