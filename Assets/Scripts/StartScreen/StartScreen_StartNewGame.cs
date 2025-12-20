using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen_StartNewGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartNewGame);   
    }
    void StartNewGame()
    {
        SceneManager.LoadSceneAsync("HeroChoose");
    }
}
