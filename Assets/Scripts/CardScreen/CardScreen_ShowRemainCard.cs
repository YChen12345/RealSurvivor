using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_ShowRemainCard : MonoBehaviour
{
    public TextMeshProUGUI num;
    public GameObject canvas;
    public GameObject button_show;
    public GameObject page;
    public CardScreen_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("CardScreen").GetComponent<CardScreen_Info>();
        button_show.GetComponent<Button>().onClick.AddListener(Show);
    }
    private void Update()
    {
        num.text = "(数量"+data.cardScreen.remainCard.Count + ")";
    }
    void Show()
    {
        GameObject p = GameObject.Instantiate(page, canvas.transform);

        p.SetActive(true);
    }
}
