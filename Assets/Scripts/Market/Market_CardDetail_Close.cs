using UnityEngine;
using UnityEngine.UI;

public class Market_CardDetail_Close : MonoBehaviour
{
    public GameObject detailPage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Close);
    }

    // Update is called once per frame
    void Close()
    {
        Destroy(detailPage);
    }
}
