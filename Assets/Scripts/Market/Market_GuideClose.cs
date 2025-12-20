using UnityEngine;
using UnityEngine.UI;

public class Market_GuideClose : MonoBehaviour
{
    public GameObject guidePage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CloseGuidePage);
    }

    void CloseGuidePage()
    {
        guidePage.SetActive(false);
    }
}
