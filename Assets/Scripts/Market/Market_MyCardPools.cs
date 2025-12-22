using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_MyCardPools : MonoBehaviour
{
    public List<GameObject> template;
    public GameObject cardpool;
    public GameObject cardpool_locked;
    List<GameObject> pools=new List<GameObject>();
    public Market_Info data;
    public int currentLev;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        currentLev = data.bd.marketLevel;
        ResetCardPools();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLev != data.bd.marketLevel) 
        {
            currentLev = data.bd.marketLevel;
            ResetCardPools();
        }
    }
    void ResetCardPools()
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i] != null)
            {
                Destroy(pools[i]);
            }
        }
        pools.Clear();
        for (int i = 0; i < template.Count; i++)
        {
            if (i <= data.bd.marketLevel)
            {
                GameObject p = GameObject.Instantiate(cardpool, cardpool.transform.parent);
                p.transform.position = template[i].transform.position;
                p.GetComponent<Market_CardPool>().pid = i;
                pools.Add(p);
                p.SetActive(true);
            }
            else
            {
                GameObject p = GameObject.Instantiate(cardpool_locked, cardpool_locked.transform.parent);
                p.transform.position = template[i].transform.position;
                p.GetComponent<Market_LockedCardPool>().pid = i;
                pools.Add(p);
                p.SetActive(true);
            }         
        }
    }
}
