using UnityEngine;
using UnityEngine.UI;
public class Market_RemovePage : MonoBehaviour
{
    public GameObject button_yes;
    public GameObject button_no;
    public int rid;
    public Market_Info data;
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        button_yes.GetComponent<Button>().onClick.AddListener(Yes);
        button_no.GetComponent<Button>().onClick.AddListener(No);
    }

    void Yes()
    {
        data.bd.cardList_Total.Remove(rid);
        data.bd.cardList_Weapon.Remove(rid);
        data.bd.cardList_Item.Remove(rid);
        data.bd.cardList_Scroll.Remove(rid);
        Destroy(this.gameObject);
    }
    void No()
    {
        Destroy(this.gameObject);
    }
}
