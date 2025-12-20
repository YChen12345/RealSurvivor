using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_WeaponAndItem : MonoBehaviour
{
    public TextMeshProUGUI weaponBag;
    public TextMeshProUGUI itemBag;
    public Market_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        weaponBag.text = data.bd.weaponLimit+"/"+"5";
        itemBag.text = data.bd.itemLimit + "/" + "5";
    }

    // Update is called once per frame
    void Update()
    {
        weaponBag.text = data.bd.weaponLimit + "/" + "5";
        itemBag.text = data.bd.itemLimit + "/" + "5";
    }
}
