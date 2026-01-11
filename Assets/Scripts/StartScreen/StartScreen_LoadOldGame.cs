using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartScreen_LoadOldGame : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject loadingPage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int state = PlayerPrefs.GetInt("State",0);
        if (state == 0)
        {
            this.gameObject.SetActive(false);
        }
        GetComponent<Button>().onClick.AddListener(LoadOldGame);
    }

    // Update is called once per frame
    void LoadOldGame()
    {
        BattleData bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        bd.loadData();
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "CardScreen";
    }
}
