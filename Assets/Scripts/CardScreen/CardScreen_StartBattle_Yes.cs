using UnityEngine;
using UnityEngine.UI;
public class CardScreen_StartBattle_Yes : MonoBehaviour
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
        loadingPage.GetComponent<LoadingPage>().sceneName = "Battle";
        confirm.SetActive(false);
    }
}
