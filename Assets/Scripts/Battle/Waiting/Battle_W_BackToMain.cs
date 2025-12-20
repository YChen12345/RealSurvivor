using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_BackToMain : MonoBehaviour
{
    public GameObject CONFIRM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BackToMain);
    }

    void BackToMain()
    {
        //Time.timeScale = 1;
        //SceneManager.LoadSceneAsync("StartScreen");
        CONFIRM.SetActive(true);
    }
}
