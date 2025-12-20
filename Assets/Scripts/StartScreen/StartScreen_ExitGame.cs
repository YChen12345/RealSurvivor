using UnityEngine;
using UnityEngine.UI;
public class StartScreen_ExitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
