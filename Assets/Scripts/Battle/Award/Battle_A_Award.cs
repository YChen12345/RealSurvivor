using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Battle_A_Award : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public List<GameObject> template;
    public GameObject gift;
    public TextMeshProUGUI text_remain;
    public Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        SetGifts();
        text_remain.text = "剩余"+data.bd.awardNum+"个奖励待领取";
    }

    // Update is called once per frame
    void SetGifts()
    {
        for(int i=0; i<template.Count; i++)
        {
            GameObject g = GameObject.Instantiate(gift, gift.transform.parent);
            g.transform.position = template[i].transform.position;
            g.GetComponent<Battle_A_Gift>().gid = i;
            g.SetActive(true);
        }
    }
}
