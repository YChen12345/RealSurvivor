using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_HeroFigure_V : MonoBehaviour
{
    public List<GameObject> template_v;
    public GameObject feature_v;
    public GameObject button_nextPage;
    List<GameObject> display_list = new List<GameObject>();
    public CardScreen_Info data;
    public int pageNum;
    public int currentPage;

    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        button_nextPage.GetComponent<Button>().onClick.AddListener(NextPage);
        Display();
    }
    void Update()
    {
        if (currentPage != pageNum)
        {
            currentPage = pageNum;
            Display();
        }
    }
    void Display()
    {
        for (int i = 0; i < display_list.Count; i++)
        {
            if (display_list[i] != null)
            {
                Destroy(display_list[i]);
            }
        }
        display_list.Clear();
        for (int i = 0; i < template_v.Count; i++)
        {
            int index = pageNum * template_v.Count + i;
            if (index < 13)
            {
                GameObject f = GameObject.Instantiate(feature_v, feature_v.transform.parent);
                f.transform.position = template_v[i].transform.position;
                f.GetComponent<CardScreen_HeroFeature>().mode = 1;
                f.GetComponent<CardScreen_HeroFeature>().fid = index;
                display_list.Add(f);
                f.SetActive(true);
            }
            else
            {
                break;
            }
        }
    }
    void NextPage()
    {
        if (pageNum < 13 / template_v.Count)
        {
            pageNum++;
        }
        else
        {
            pageNum = 0;
        }
    }
}
