using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Market_RemoveDescriptionClose : MonoBehaviour
{
    public GameObject page;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Close);
    }

    void Close()
    {
        Destroy(page);
    }
}
