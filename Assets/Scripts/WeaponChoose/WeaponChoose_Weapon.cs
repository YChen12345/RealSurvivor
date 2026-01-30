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
    GameObject image;
    public WeaponChoose_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("WeaponChoose").GetComponent<WeaponChoose_Info>();
        weaponID = data.bd.heroID * 3 + index;
        GetComponent<Button>().onClick.AddListener(ChooseWeapon);
        image = this.gameObject;
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        Config_D_weapon d_weapon = uf.LoadStructFromJson<Config_D_weapon>("Config/D/Config_D_weapon");
        weapon_name.text = d_weapon.weaponDesList[weaponID].weapon_name;
        if (!data.pd.weaponList.Contains(weaponID))
        {
            this.gameObject.SetActive(false);
        }
    }

    void ChooseWeapon()
    {
        data.bd.weaponID = weaponID;
        PlayerPrefs.SetInt("State", 0);
        uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "Battle";
    }
}
