using UnityEngine;
using UnityEngine.UI;
public class CardScreen_RemainCard_Weapon : MonoBehaviour
{
    public GameObject remaincard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisPlayAll);
    }

    void DisPlayAll()
    {
        remaincard.GetComponent<CardScreen_RemainCard>().state = 1;
    }
}
