using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class WeaponChoose_Weapon : MonoBehaviour
{
    public GameObject loadingPage;
    public int index;
    public int weaponID;
    public TextMeshProUGUI weapon_name;
    IUF uf;
    BattleData bd;
    PlayerData pd;
    GameObject image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        weaponID = bd.heroID * 3 + index;
        GetComponent<Button>().onClick.AddListener(ChooseWeapon);
        image = this.gameObject;
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        Config_D_weapon d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        weapon_name.text = d_weapon.weaponDesList[weaponID].weapon_name;
        if (!pd.weaponList.Contains(weaponID))
        {
            this.gameObject.SetActive(false);
        }
    }

    void ChooseWeapon()
    {
        bd.weaponID = weaponID;
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "LevelChoose";
    }
}
