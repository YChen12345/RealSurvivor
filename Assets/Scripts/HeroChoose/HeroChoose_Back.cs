using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroChoose_Back : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    void Back()
    {
        SceneManager.LoadSceneAsync("StartScreen");
    }
}
