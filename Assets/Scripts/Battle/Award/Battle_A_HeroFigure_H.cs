using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Battle_A_HeroFigure_H : MonoBehaviour
{
    public List<GameObject> template_h;
    public GameObject feature_h;
    public Battle_Info data;

    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        Display();
    }
    void Display()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject f = GameObject.Instantiate(feature_h, feature_h.transform.parent);
            f.transform.position = template_h[i].transform.position;
            f.GetComponent<Battle_A_HeroFeature>().mode = 0;
            f.GetComponent<Battle_A_HeroFeature>().fid = i;
            f.SetActive(true);
        }
    }
}
