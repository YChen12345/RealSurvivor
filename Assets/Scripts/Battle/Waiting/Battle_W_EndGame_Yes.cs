using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_EndGame_Yes : MonoBehaviour
{
    public GameObject loadingPage;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EndGame);
    }

    void EndGame()
    {
        Time.timeScale = 1;
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "Lose";
    }
}
