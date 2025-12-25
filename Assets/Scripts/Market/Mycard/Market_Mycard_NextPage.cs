using UnityEngine;
using UnityEngine.UI;
public class Market_Mycard_NextPage : MonoBehaviour
{
    public GameObject button;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button.GetComponent<Button>().onClick.AddListener(NextPage);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Market_Mycard>().pageNum * GetComponent<Market_Mycard>().template.Count 
            >= data.bd.cardList_Total.Count - GetComponent<Market_Mycard>().template.Count)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
    void NextPage()
    {
        GetComponent<Market_Mycard>().pageNum++;
    }
}
