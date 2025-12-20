using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_MainPage_Yes : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BackToMain);
    }

    void BackToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("StartScreen");
    }
}
