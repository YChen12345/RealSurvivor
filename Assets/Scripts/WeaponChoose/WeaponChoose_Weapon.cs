using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WeaponChoose_Weapon : MonoBehaviour
{
    public int index;
    int weaponID;
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
        if (!pd.weaponList.Contains(weaponID))
        {
            this.gameObject.SetActive(false);
        }
    }

    void ChooseWeapon()
    {
        bd.weaponID = weaponID;
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        SceneManager.LoadSceneAsync("LevelChoose");
    }
}
