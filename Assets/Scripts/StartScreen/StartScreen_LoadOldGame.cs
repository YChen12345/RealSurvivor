using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartScreen_LoadOldGame : MonoBehaviour
{
    public GameObject loadingPage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int state = PlayerPrefs.GetInt("State",0);
        if (state == 0)
        {
            this.gameObject.SetActive(false);
        }
        GetComponent<Button>().onClick.AddListener(LoadOldGame);
    }

    // Update is called once per frame
    void LoadOldGame()
    {
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "CardScreen";
    }
}
