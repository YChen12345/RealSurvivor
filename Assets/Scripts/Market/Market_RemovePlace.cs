using UnityEngine;
using UnityEngine.UI;
public class Market_RemovePlace : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject icon;
    public Market_Info data;
    public int state;
    Vector3 originScaling;
    void Start()
    {
        originScaling = icon.transform.localScale;
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("RemovePlace", 0);
    }
    void Update()
    {
        if (state > 0)
        {
            icon.transform.localScale = originScaling * 1.1f;
            icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("RemovePlace", 1);
        }
        else
        {
            icon.transform.localScale = originScaling;
            icon.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("RemovePlace", 0);
        }
    }
}
