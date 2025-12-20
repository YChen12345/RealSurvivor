using UnityEngine;
using UnityEngine.UI;
public class Market_Guide : MonoBehaviour
{
    public GameObject guidePage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenGuidePage);
    }

    void OpenGuidePage()
    {
        guidePage.SetActive(true);
    }
}
