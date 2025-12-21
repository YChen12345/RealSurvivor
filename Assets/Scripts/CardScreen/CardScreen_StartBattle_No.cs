using UnityEngine;
using UnityEngine.UI;
public class CardScreen_StartBattle_No : MonoBehaviour
{
    public GameObject confirm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(No);
    }

    void No()
    {
        confirm.SetActive(false);
    }
}
