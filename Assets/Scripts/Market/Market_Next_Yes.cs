using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Market_Next_Yes : MonoBehaviour
{
    public GameObject loadingPage;
    public GameObject confirm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Yes);
    }

    void Yes()
    {
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "CardScreen";
        confirm.SetActive(false);
    }
}
