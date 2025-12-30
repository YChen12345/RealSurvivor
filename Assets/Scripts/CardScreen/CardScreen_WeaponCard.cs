using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CardScreen_WeaponCard : MonoBehaviour
{
    public int weaponID;
    IUF uf = new UIFunctions();
    public GameObject canvas;
    public GameObject avatar;
    public GameObject trigger;
    public GameObject detail;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        weaponID = data.bd.weaponID;
        avatar.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        trigger.GetComponent<Button>().onClick.AddListener(SeeDetail);
    }
    void SeeDetail()
    {
        GameObject d = GameObject.Instantiate(detail, detail.transform.parent);
        d.transform.parent = canvas.transform;
        d.GetComponent<CardScreen_WeaponCardDetail>().weaponID = weaponID;
        d.SetActive(true);
    }
}
