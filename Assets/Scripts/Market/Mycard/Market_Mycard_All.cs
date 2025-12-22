using UnityEngine;
using UnityEngine.UI;
public class Market_Mycard_All : MonoBehaviour
{
    public GameObject mycard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisPlayAll);
    }

    void DisPlayAll()
    {
        mycard.GetComponent<Market_Mycard>().state = 0;
    }
}
