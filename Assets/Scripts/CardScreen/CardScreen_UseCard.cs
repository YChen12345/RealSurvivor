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
    }

    // Update is called once per frame
    void Update()
    { 
        if (uf.InArea(this.transform.position, uf.Area(usePlace)))
        {
            int cid = GetComponent<CardScreen_HandCard>().cid;
            if (state == 0)
            {
                state = 1;
                usePlace.GetComponent<CardScreen_UseCardPlace>().state++;
                usePlace.GetComponent<CardScreen_UseCardPlace>().use_state = 0;
            }
            switch (data.cards.cards[cid].kind)
            {
                case 0:
                    if (data.bd.WeaponCardList.Count >= data.bd.weaponLimit)
                    {
                        usePlace.GetComponent<CardScreen_UseCardPlace>().use_state = 1;
                    }
                    break;
                case 1:
                    if (data.bd.ItemCardList.Count >= data.bd.itemLimit)
                    {
                        usePlace.GetComponent<CardScreen_UseCardPlace>().use_state = 1;
                    }
                    break;
                case 2:
                    if (data.bd.ScrollCardList.Count >= 5)
                    {
                        usePlace.GetComponent<CardScreen_UseCardPlace>().use_state = 1;
                    }
                    break;
            }
            if (data.cards.cards[cid].cost > data.bd.mana)
            {
                usePlace.GetComponent<CardScreen_UseCardPlace>().use_state = 2;
            }
            Use();
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
    void Use()
    {
        int cid = GetComponent<CardScreen_HandCard>().cid;
        if (Input.GetMouseButtonUp(0))
        {
            if (state == 1)
            {
                state = 0;
                usePlace.GetComponent<CardScreen_UseCardPlace>().state--;
            }
            originPosition = GetComponent<CardScreen_HandCard>().originPos;
            this.gameObject.transform.position = originPosition;
            if (data.cards.cards[cid].cost <= data.bd.mana)
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
                data.bd.mana -= data.cards.cards[cid].cost;
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
}
