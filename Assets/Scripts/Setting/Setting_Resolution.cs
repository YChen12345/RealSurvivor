using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Setting_Resolution : MonoBehaviour
{
    IUF uf = new UIFunctions();
    PlayerData pd;
    public GameObject choice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        choice.GetComponent<TMP_Dropdown>().value = pd.resolution;
    }

    // Update is called once per frame
    void Update()
    {
        if (choice.GetComponent<TMP_Dropdown>().value != pd.resolution)
        {
            pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
            pd.resolution = choice.GetComponent<TMP_Dropdown>().value;
            uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
        }
    }
}
