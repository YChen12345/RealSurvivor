using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_RemainCard_Close : MonoBehaviour
{
    public GameObject button_close;
    public GameObject page;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_close.GetComponent<Button>().onClick.AddListener(Close);
    }

    // Update is called once per frame
    void Close()
    {
        Destroy(page);
    }
}
