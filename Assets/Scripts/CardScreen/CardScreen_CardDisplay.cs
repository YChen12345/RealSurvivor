using UnityEngine;
using UnityEngine.UI;
public class CardScreen_CardDisplay : MonoBehaviour
{
    public int cid;
    IUF uf = new UIFunctions();
    public GameObject front;
    public GameObject back;
    CardScreen_Info data;
    private void OnEnable()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        CardPage cp = GetComponent<CardPage>();
        cp.cid = cid;
        cp.cards = data.cards;
        cp.d_card = data.d_card;
        cp.ShowMessage();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        front.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.SetActive(false);
    }
}
