using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_HeroFigure_H : MonoBehaviour
{
    public List<GameObject> template_h;
    public GameObject feature_h;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        Display();
    }
    void Display()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject f = GameObject.Instantiate(feature_h, feature_h.transform.parent);
            f.transform.position = template_h[i].transform.position;
            f.GetComponent<CardScreen_HeroFeature>().mode = 0;
            f.GetComponent<CardScreen_HeroFeature>().fid = i;
            f.SetActive(true);
        }
    }
}
