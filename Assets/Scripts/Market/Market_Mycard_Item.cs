using UnityEngine;
using UnityEngine.UI;
public class Market_Mycard_Item : MonoBehaviour
{
    public GameObject mycard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisPlayItem);
    }

    void DisPlayItem()
    {
        mycard.GetComponent<Market_Mycard>().state = 2;
    }
}
