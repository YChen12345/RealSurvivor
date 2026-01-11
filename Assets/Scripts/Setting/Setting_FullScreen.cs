using UnityEngine;
using UnityEngine.UI;
public class Setting_FullScreen : MonoBehaviour
{
    IUF uf = new UIFunctions();
    PlayerData pd;
    public GameObject choice;
    public GameObject button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        if (pd.fullscreen)
        {
            choice.GetComponent<Scrollbar>().value = 1;
        }
        else
        {
            choice.GetComponent<Scrollbar>().value = 0;
        }
        button.GetComponent<Button>().onClick.AddListener(Change);
    }

    // Update is called once per frame
    void Change()
    {
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        if (pd.fullscreen)
        {
            pd.fullscreen = false;
        }
        else
        {
            pd.fullscreen = true;
        }
        if (pd.fullscreen)
        {
            choice.GetComponent<Scrollbar>().value = 1;
        }
        else
        {
            choice.GetComponent<Scrollbar>().value = 0;
        }
        uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
    }
}
