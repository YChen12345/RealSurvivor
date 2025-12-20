using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Lose_Restart : MonoBehaviour
{
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
        SceneManager.LoadSceneAsync("Battle");
    }
}
