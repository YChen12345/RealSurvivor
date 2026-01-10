using UnityEngine;
using UnityEngine.UI;
public class CardScreen_RemoveEquipPlace : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject active_icon;
    public GameObject image;
    public CardScreen_Info data;
    public int state;
    public int view_state;
    Vector3 originScaling;
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
    }
    void Update()
    {
        if (view_state > 0)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
        if (state == 1)
        {
            active_icon.SetActive(true);
        }
        else
        {
            active_icon.SetActive(false);
        }
    }
}
