using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScreen_EmyCard : MonoBehaviour
{
    public int eid;
    public GameObject canvas;
    public GameObject icon;
    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_description;
    public GameObject detail;
    public GameObject button_showDetail;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("EmyCard/Emy", eid);
        text_name.text = "";
        text_description.text = "";
        button_showDetail.GetComponent<Button>().onClick.AddListener(ShowDetail);
    }

    void ShowDetail()
    {
        GameObject p = GameObject.Instantiate(detail,canvas.transform);
        p.GetComponent<CardScreen_EmyDetail>().eid = eid;
        p.SetActive(true);
    }
}
