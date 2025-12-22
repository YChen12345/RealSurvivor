using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Market_RemoveDescription : MonoBehaviour
{
    public GameObject canvas;
    public GameObject page;
    public TextMeshProUGUI text_content;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Open);
        text_content.text = "将卡牌拖动至此以销毁卡牌！";

    }
    void Open()
    {
        GameObject p = GameObject.Instantiate(page,canvas.transform);
        p.SetActive(true);
    }
}
