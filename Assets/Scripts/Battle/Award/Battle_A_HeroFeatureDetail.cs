using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Battle_A_HeroFeatureDetail : MonoBehaviour
{
    public int fid;
    public int mode;
    public TextMeshProUGUI content;
    public Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        Description();
    }

    void Description()
    {
        content.text = "";
    }
}
