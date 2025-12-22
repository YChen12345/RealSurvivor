using UnityEngine;
using UnityEngine.UI;

public class Market_Mycard_LastPage : MonoBehaviour
{
    public GameObject button;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button.GetComponent<Button>().onClick.AddListener(LastPage);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Market_Mycard>().pageNum == 0)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
    void LastPage()
    {
        GetComponent<Market_Mycard>().pageNum--;
    }
}
