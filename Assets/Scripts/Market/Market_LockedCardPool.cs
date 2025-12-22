using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_LockedCardPool : MonoBehaviour
{
    public int pid;
    public GameObject icon;
    IUF uf = new UIFunctions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("CardPool", pid);
    }
}
