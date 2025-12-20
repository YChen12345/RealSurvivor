using UnityEngine;

public class Market_CardDetail : MonoBehaviour
{
    public int cid;
    public GameObject card;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        card.GetComponent<Market_CardDisplay>().cid = cid;
    }
}
