using UnityEngine;
using UnityEngine.UI;
public class Setting_Sound : MonoBehaviour
{
    IUF uf = new UIFunctions();
    PlayerData pd;
    public GameObject choice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        choice.GetComponent<Slider>().value = pd.sound;
    }

    // Update is called once per frame
    void Update()
    {
        if (choice.GetComponent<Slider>().value != pd.sound)
        {
            pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
            pd.sound = choice.GetComponent<Slider>().value;
            uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
        }
    }
}
