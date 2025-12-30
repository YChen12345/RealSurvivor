using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CardScreen_HeroCardDetail : MonoBehaviour
{
    public int heroID;
    IUF uf = new UIFunctions();
    public GameObject page;
    public GameObject avatar;
    public TextMeshProUGUI text_content;
    public GameObject button_close;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        avatar.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("HeroCard", heroID);
        button_close.GetComponent<Button>().onClick.AddListener(Close);
    }
    void Close()
    {
        Destroy(page);
    }
}
