using UnityEngine;
using UnityEngine.UI;
public class CardScreen_UseCardPlace : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public CardScreen_Info data;
    public GameObject active_icon;
    public GameObject false_icon_1;
    public GameObject false_icon_2;
    public int state;
    public int use_state;
    Vector3 originScaling;
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
    }
    void Update()
    {
        if(state == 1)
        {
            if (use_state == 0)
            {
                active_icon.SetActive(true);
                false_icon_1.SetActive(false);
                false_icon_2.SetActive(false);
            }
            else if(use_state == 1)
            {
                active_icon.SetActive(false);
                false_icon_1.SetActive(true);
                false_icon_2.SetActive(false);
            }
            else if (use_state == 2)
            {
                active_icon.SetActive(false);
                false_icon_1.SetActive(false);
                false_icon_2.SetActive(true);
            }
        }
        else
        {
            active_icon.SetActive(false);
            false_icon_1.SetActive(false);
            false_icon_2.SetActive(false);
        }
    }
}
