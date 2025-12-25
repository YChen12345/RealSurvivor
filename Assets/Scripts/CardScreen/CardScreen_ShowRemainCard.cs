using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CardScreen_ShowRemainCard : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button_show;
    public GameObject page;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_show.GetComponent<Button>().onClick.AddListener(Show);
    }

    void Show()
    {
        GameObject p = GameObject.Instantiate(page, canvas.transform);

        p.SetActive(true);
    }
}
