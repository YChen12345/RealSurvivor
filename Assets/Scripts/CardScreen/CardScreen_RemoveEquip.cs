using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScreen_RemoveEquip : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject canvas;
    public GameObject removePlace;
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
        if (uf.InArea(this.transform.position, uf.Area(removePlace)))
        {
            if (state == 0)
            {
                state = 1;
                removePlace.GetComponent<CardScreen_RemoveEquipPlace>().state++;
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.gameObject.transform.position = originPosition;
                int cid = GetComponent<CardScreen_EquippedCard>().cid;
                switch (data.cards.cards[cid].kind)
                {
                    case 0:
                        data.bd.WeaponCardList.Remove(cid);
                        break;
                    case 1:
                        data.bd.ItemCardList.Remove(cid);
                        break;
                    case 2:
                        data.bd.ScrollCardList.Remove(cid);
                        break;
                }
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (state == 1)
            {
                state = 0;
                removePlace.GetComponent<CardScreen_RemoveEquipPlace>().state--;
            }
        }
    }
}
