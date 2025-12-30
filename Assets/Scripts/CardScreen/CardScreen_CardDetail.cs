using UnityEngine;

public class CardScreen_CardDetail : MonoBehaviour
{
    public int cid;
    public GameObject card;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        card.GetComponent<CardScreen_CardDisplay>().cid = cid;
    }
}
