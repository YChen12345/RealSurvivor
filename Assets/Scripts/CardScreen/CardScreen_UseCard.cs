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
                if (state == 1)
                {
                    state = 0;
                    usePlace.GetComponent<CardScreen_UseCardPlace>().state--;
                }
                this.gameObject.transform.position = originPosition;
                int cid = GetComponent<CardScreen_HandCard>().cid;
                if (data.cards.cards[cid].cost <= data.hd.mana)
                {
                    switch (data.cards.cards[cid].kind)
                    {
                        case 0:
                            if (data.bd.WeaponCardList.Count >= data.bd.weaponLimit)
                            {
                                return;
                            }
                            break;
                        case 1:
                            if (data.bd.ItemCardList.Count >= data.bd.itemLimit)
                            {
                                return;
                            }
                            break;
                        case 2:
                            if (data.bd.ScrollCardList.Count >= 5)
                            {
                                return;
                            }
                            break;
                    }
                    data.hd.mana-=data.cards.cards[cid].cost;
                    ////
                    data.cardScreen.cardUsed_thisRound++;
                    data.cardScreen.handCard[GetComponent<CardScreen_HandCard>().index] = -1;

                    data.bd.cardList_Used.Add(cid);
                    switch (data.cards.cards[cid].kind)
                    {
                        case 0:
                            data.bd.WeaponCardList.Add(cid);
                            break;
                        case 1:
                            data.bd.ItemCardList.Add(cid);
                            break;
                        case 2:
                            data.bd.ScrollCardList.Add(cid);
                            break;
                    }
                    data.ComputeHeroFeature();
                    Destroy(this.gameObject);
                }
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
