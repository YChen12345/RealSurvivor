using UnityEngine;
using UnityEngine.UI;
public class Market_Mycard_Scroll : MonoBehaviour
{
    public GameObject mycard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisPlayScroll);
    }

    void DisPlayScroll()
    {
        mycard.GetComponent<Market_Mycard>().state = 3;
    }
}
