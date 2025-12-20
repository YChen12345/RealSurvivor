using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Market_Next : MonoBehaviour
{
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
        if (data.bd.gold < data.market.draw_cost[0])
        {
            SceneManager.LoadSceneAsync("CardScreen");
        }
        else
        {
            confirm.SetActive(true);
        }
    }
}
