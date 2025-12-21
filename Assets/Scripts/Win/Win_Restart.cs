using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Win_Restart : MonoBehaviour
{
    public GameObject loadingPage;
    IUF uf;
    BattleData bd;
    int hid;
    int wid;
    int lid;
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        hid = bd.heroID;
        wid = bd.weaponID;
        lid = bd.levelID;
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        bd.Init();
        bd.heroID = hid;
        bd.weaponID = wid;
        bd.levelID = lid;
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "Battle";
    }
}
