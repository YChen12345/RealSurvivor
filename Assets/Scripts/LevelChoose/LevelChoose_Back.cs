using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelChoose_Back : MonoBehaviour
{
    public GameObject loadingPage;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    void Back()
    {
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "WeaponChoose";
    }
}
