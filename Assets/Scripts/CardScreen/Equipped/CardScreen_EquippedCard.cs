using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_EquippedCard : MonoBehaviour
{
    public int cid;
    public GameObject canvas;
    IUF uf = new UIFunctions();
    IUITools tools_parent = new UITools();
    IUITools tools_Card = new UITools();
    IUITools tools_Trigger = new UITools();
    public GameObject parent;
    public GameObject avatar;
    public GameObject front;
    public GameObject back;
    public GameObject trigger;
    public GameObject detail;
    int click_state;
    float click_timer;

    Vector3 offset;
    public int state;
    public int moveState;
    Vector2 originPos;
    void Start()
    {
        front.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.SetActive(false);
        tools_Trigger.AddEntryEvent(trigger);
        tools_Trigger.AddExitEvent(trigger);
        tools_Trigger.AddButtonClick(trigger);
        originPos = transform.position;
        tools_Card.RecordSiblingIndex(this.gameObject);
        tools_parent.RecordSiblingIndex(parent);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SeeDetail();
    }
    void Move()
    {
        if (moveState == 0)
        {
            offset = uf.GetOffsetOfMouse(this.gameObject);
            uf.ObjMoveTo(this.gameObject, originPos, 15);
            avatar.transform.forward = Vector3.forward;
            if (tools_Trigger.Entry())
            {
                state = 1;
            }
            if (tools_Trigger.Exit())
            {
                state = 0;
            }
        }
        if (state == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveState = 1;
                tools_Card.SetAsLastSibling(this.gameObject);
                tools_parent.SetAsLastSibling(parent);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveState = 0;
            tools_Card.SetSiblingBack(this.gameObject);
            tools_parent.SetSiblingBack(parent);
        }
        if (moveState == 1)
        {
            uf.MoveByMouse(this.gameObject, offset, 30);
            uf.ObjRotateByCenterByMouse(this.gameObject, avatar, 30, 3);
        }
    }
    void SeeDetail()
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
                d.GetComponent<CardScreen_CardDetail>().cid = cid;
                d.SetActive(true);
            }
        }
    }
}
