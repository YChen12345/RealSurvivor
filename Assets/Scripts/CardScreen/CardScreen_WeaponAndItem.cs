using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_WeaponAndItem : MonoBehaviour
{
    public TextMeshProUGUI weaponBag;
    public TextMeshProUGUI itemBag;
    public TextMeshProUGUI scrollBag;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        weaponBag.text = data.bd.WeaponCardList.Count + "/" + data.bd.weaponLimit;
        itemBag.text = data.bd.ItemCardList.Count + "/" + data.bd.itemLimit;
        scrollBag.text = data.bd.ScrollCardList.Count + "/" + "5";
    }

    // Update is called once per frame
    void Update()
    {
        weaponBag.text = data.bd.WeaponCardList.Count + "/" + data.bd.weaponLimit;
        itemBag.text = data.bd.ItemCardList.Count + "/" + data.bd.itemLimit;
        scrollBag.text = data.bd.ScrollCardList.Count + "/" + "5";
    }
}
