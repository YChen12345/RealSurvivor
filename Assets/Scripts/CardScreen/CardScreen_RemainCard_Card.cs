using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_RemainCard_Card : MonoBehaviour
{
    public int cid;
    public GameObject canvas;
    IUF uf = new UIFunctions();
    IUITools tools_Trigger = new UITools();
    public GameObject avatar;
    public GameObject front;
    public GameObject back;
    public GameObject trigger;
    public GameObject detail;
    public int state;
    public int moveState;
    int click_state;
    float click_timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        front.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.SetActive(false);
        tools_Trigger.AddButtonClick(trigger);
    }

    // Update is called once per frame
    void Update()
    {
        if (click_state == 0)
        {
            if (tools_Trigger.ButtonClicked())
            {
                click_state = 1;
                click_timer = 0;
            }
        }
        else if (click_state == 1)
        {
            click_timer += Time.deltaTime;
            if (click_timer > 0.3f)
            {
                click_timer = 0;
                click_state = 0;
            }
            if (tools_Trigger.ButtonClicked())
            {
                click_state = 0;
                GameObject d = GameObject.Instantiate(detail, canvas.transform);
                d.GetComponent<Market_CardDetail>().cid = cid;
                d.SetActive(true);
            }
        }
    }
}
