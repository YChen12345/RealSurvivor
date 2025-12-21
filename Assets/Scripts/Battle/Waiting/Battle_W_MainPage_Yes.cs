using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_MainPage_Yes : MonoBehaviour
{
    public GameObject loadingPage;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BackToMain);
    }

    void BackToMain()
    {
        Time.timeScale = 1;
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "StartScreen";
    }
}
