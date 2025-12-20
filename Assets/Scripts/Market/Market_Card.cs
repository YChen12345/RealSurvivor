using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Market_Card : MonoBehaviour
{
    public int cid;
    public GameObject canvas;
    Vector2 originPos;
    IUF uf = new UIFunctions();
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
    }

    // Update is called once per frame
    void Update()
    {      
        if (moveState == 0)
        {
            offset = uf.GetOffsetOfMouse(this.gameObject);
            uf.ObjMoveTo(this.gameObject, originPos, 10);
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
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moveState = 0;
        }
        if (moveState == 1)
        {
            uf.MoveByMouse(this.gameObject, offset, 9);
            uf.ObjRotateByCenterByMouse(this.gameObject, avatar, 30, 3);
        }
        if (tools_Trigger.ButtonClicked())
        {
            click_state = 1;
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
                click_state = 0;
                GameObject d = GameObject.Instantiate(detail,canvas.transform);
                d.GetComponent<Market_CardDetail>().cid = cid;
                d.SetActive(true);
            }
        }
    }
}
