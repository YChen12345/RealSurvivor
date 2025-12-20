using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MyMarketCards : MonoBehaviour
{
    public List<GameObject> template;
    public GameObject marketcard;
    public GameObject button_lock;
    public GameObject button_unlock;
    public GameObject button_refresh;
    List<GameObject> display_list = new List<GameObject>();  
    List<int> cid_list= new List<int>() { 0, 0, 0, 0 };
    public Market_Info data;
   
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_lock.GetComponent<Button>().onClick.AddListener(Lock);
        button_unlock.GetComponent<Button>().onClick.AddListener(UnLock);
        button_refresh.GetComponent<Button>().onClick.AddListener(Refresh);
        button_lock.SetActive(true);
        button_unlock.SetActive(false);
        SetProduct();
    }

    void SetProduct()
    {
        for(int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        for(int i = 0; i < template.Count; i++)
        {
            GameObject p = GameObject.Instantiate(marketcard, marketcard.transform.parent);
            p.transform.position = template[i].transform.position;
            p.GetComponent<Market_CardDisplay>().cid = cid_list[i];
            p.GetComponent<Market_MarketCard>().cid = cid_list[i];
            display_list.Add(p);
            p.SetActive(true);
        }
    }
    void Lock()
    {
        button_lock.SetActive(false);
        button_unlock.SetActive(true);
    }
    void UnLock()
    {
        button_lock.SetActive(true);
        button_unlock.SetActive(false);
    }
    void Refresh()
    {
        for (int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            GameObject p = GameObject.Instantiate(marketcard, marketcard.transform.parent);
            p.transform.position = template[i].transform.position;
            p.GetComponent<Market_CardDisplay>().cid = cid_list[i];
            p.GetComponent<Market_MarketCard>().cid = cid_list[i];
            display_list.Add(p);
            p.SetActive(true);
        }
    }
}
