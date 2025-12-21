using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelChoose_Level : MonoBehaviour
{
    public GameObject loadingPage;
    public int levelID;
    IUF uf;
    BattleData bd;
    PlayerData pd;
    HeroData hd;
    void Start()
    {
        uf = new Functions();
        hd.init();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        GetComponent<Button>().onClick.AddListener(ChooseLevel);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        if (pd.levelList[bd.heroID]<levelID)
        {
            this.gameObject.SetActive(false);
        }
    }

    void ChooseLevel()
    {
        bd.levelID = levelID;
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        uf.SaveStructToJson<HeroData>(hd, "Data/HeroData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "Battle";
    }
}
