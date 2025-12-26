using UnityEngine;

public class CardScreen_UseCard : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject canvas;
    public GameObject usePlace;
    public CardScreen_Info data;

    Vector3 originPosition;
    int state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (uf.InArea(this.transform.position, uf.Area(usePlace)))
        {
            if (state == 0)
            {
                state = 1;
                usePlace.GetComponent<CardScreen_UseCardPlace>().state++;
            }
            if (Input.GetMouseButtonUp(0))
            {
                data.cardScreen.cardUsed_thisRound++;
                data.cardScreen.handCard[GetComponent<CardScreen_HandCard>().index] = -1;
                data.bd.cardList_Used.Add(GetComponent<CardScreen_HandCard>().cid);
                data.bd.WeaponCardList.Add(GetComponent<CardScreen_HandCard>().cid);
                data.bd.ItemCardList.Add(GetComponent<CardScreen_HandCard>().cid);
                data.bd.ScrollCardList.Add(GetComponent<CardScreen_HandCard>().cid);
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (state == 1)
            {
                state = 0;
                usePlace.GetComponent<CardScreen_UseCardPlace>().state--;
            }
        }
    }
}
