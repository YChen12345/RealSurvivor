using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CardScreen_StartBattle : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject loadingPage;
    public GameObject confirm;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        GetComponent<Button>().onClick.AddListener(StartBattle);
    }

    // Update is called once per frame
    void StartBattle()
    {
        uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
        if (data.hd.mana <=1)
        {
            loadingPage.SetActive(true);
            loadingPage.GetComponent<LoadingPage>().sceneName = "Battle";
        }
        else
        {
            confirm.SetActive(true);
        }
    }
}
