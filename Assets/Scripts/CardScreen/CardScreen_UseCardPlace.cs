using UnityEngine;
using UnityEngine.UI;
public class CardScreen_UseCardPlace : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public CardScreen_Info data;
    public int state;
    Vector3 originScaling;
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
    }
    void Update()
    {

    }
}
