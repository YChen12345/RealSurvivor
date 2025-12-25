using UnityEngine;
using UnityEngine.UI;
public class CardScreen_RemainCard_Detail : MonoBehaviour
{
    int state;
    public GameObject detailButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Detail);
    }

    void Detail()
    {
        if (state == 0)
        {
            state = 1;
            detailButtons.SetActive(true);
        }
        else
        {
            state = 0;
            detailButtons.SetActive(false);
        }
    }
}
