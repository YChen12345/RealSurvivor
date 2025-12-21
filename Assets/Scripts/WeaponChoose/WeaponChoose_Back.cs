using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponChoose_Back : MonoBehaviour
{
    public GameObject loadingPage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    void Back()
    {
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "HeroChoose";
    }
}
