using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Market_Next : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject loadingPage;
    public GameObject confirm;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        GetComponent<Button>().onClick.AddListener(Next);
    }

    // Update is called once per frame
    void Next()
    {
        uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
        if (data.bd.gold < data.market.draw_cost[0])
        {
            loadingPage.SetActive(true);
            loadingPage.GetComponent<LoadingPage>().sceneName = "CardScreen";
        }
        else
        {
            confirm.SetActive(true);
        }
    }
}
