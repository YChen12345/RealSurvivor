using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class HeroChoose_Money : MonoBehaviour
{
    IUF uf=new UIFunctions();
    public HeroChoose_Info data;
    public TextMeshProUGUI num;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("HeroChoose").GetComponent<HeroChoose_Info>();
        num.text = "拥有钻石：" + data.pd.money;
    }

    // Update is called once per frame
    void Update()
    {
        num.text = "拥有钻石：" + data.pd.money;
    }
}
