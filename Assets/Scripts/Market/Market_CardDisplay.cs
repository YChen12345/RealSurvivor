using UnityEngine;
using UnityEngine.UI;
public class Market_CardDisplay : MonoBehaviour
{
    public int cid;
    IUF uf = new UIFunctions();
    public GameObject front;
    public GameObject back;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        front.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("Card", cid);
        back.SetActive(false);
    }
}
