using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Effect_Button_Buy : MonoBehaviour
{
    public GameObject obj;
    public GameObject trigger;
    public float multi;
    Vector2 initSize;
    IUITools uitools_trigger;
    public int state;
    public float timer;
    void Awake()
    {
        uitools_trigger = new UITools();
        if (multi <= 0)
        {
            multi = 1.1f;
        }
        //initParent = GetComponent<RectTransform>().parent;
        if (obj == null)
        {
            initSize = GetComponent<RectTransform>().localScale;
            obj = this.gameObject;
        }
        else
        {
            initSize = obj.GetComponent<RectTransform>().localScale;
        }
        uitools_trigger.AddEntryEvent(trigger);
        uitools_trigger.AddExitEvent(trigger);
    }

    private void OnEnable()
    {
        if (obj == null)
        {
            GetComponent<RectTransform>().localScale = initSize;
        }
        else
        {
            obj.GetComponent<RectTransform>().localScale = initSize;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (state == 0)
        {
            if (timer > 0.2f)
            {
                if (uitools_trigger.Entry())
                {
                    state = 1;
                }
            }       
        }    
        else if (state == 1)
        {
            if (uitools_trigger.Exit())
            {
                state = 0;
                timer = 0;
            }
        }
        if (state == 1)
        {
            if (obj == null)
            {
                GetComponent<RectTransform>().localScale = initSize * multi;
            }
            else
            {
                obj.GetComponent<RectTransform>().localScale = initSize * multi;
            }
        }
        else
        {
            if (obj == null)
            {
                GetComponent<RectTransform>().localScale = initSize;
            }
            else
            {
                obj.GetComponent<RectTransform>().localScale = initSize;
            }
        }
    }
}
