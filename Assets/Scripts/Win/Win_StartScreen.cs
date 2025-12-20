using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Win_StartScreen : MonoBehaviour
{
    IUF uf;
    BattleData bd;
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        GetComponent<Button>().onClick.AddListener(NewGame);
    }

    void NewGame()
    {
        bd.Init();
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        SceneManager.LoadSceneAsync("StartScreen");
    }
}
