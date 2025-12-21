using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Market_Card : MonoBehaviour
{
    public int cid;
    public GameObject canvas;
    Vector2 originPos;
    IUF uf = new UIFunctions();
    IUITools tools_Card = new UITools();
    IUITools tools_Trigger = new UITools();
    public GameObject avatar;
    public GameObject front;
    public GameObject back;
    public GameObject trigger;
    public GameObject detail;
    Vector3 offset;
    public int state;
    public int moveState;
    int click_state;
    float click_timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        front.GetComponent<Image>().sprite=uf.LoadResource<Sprite>("Card", cid);
        back.GetComponent<Image>().sprite=uf.LoadResource<Sprite>("Card", cid);
        back.SetActive(false);
        tools_Trigger.AddEntryEvent(trigger);
        tools_Trigger.AddExitEvent(trigger);
        tools_Trigger.AddButtonClick(trigger);
        originPos = transform.position;
        tools_Card.RecordSiblingIndex(this.gameObject);
    }

    // Update is called once per frame
    void Update()
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
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveState = 0;
            tools_Card.SetSiblingBack(this.gameObject);
        }
        if (moveState == 1)
        {
            uf.MoveByMouse(this.gameObject, offset, 30);
            uf.ObjRotateByCenterByMouse(this.gameObject, avatar, 30, 3);
        }
        if (tools_Trigger.ButtonClicked())
        {
            click_state = 1;
            click_timer = 0;
        }
        if (click_state == 1)
        {
            click_timer += Time.deltaTime;
            if (click_timer > 0.3f)
            {
                click_timer = 0;
                click_state = 0;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (uf.Distance2(this.gameObject, originPos) < 0.5f)
                {
                    click_state = 0;
                    GameObject d = GameObject.Instantiate(detail, canvas.transform);
                    d.GetComponent<Market_CardDetail>().cid = cid;
                    d.SetActive(true);
                }              
            }
        }
    }
}
