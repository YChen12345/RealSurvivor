using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class WeaponChoose_BuyWeapon : MonoBehaviour
{
    public int index;
    int weaponID;
    public int cost;
    public TextMeshProUGUI tips_cost;
    public TextMeshProUGUI tips;
    int state;
    public GameObject weapon;
    GameObject image;
    IUF uf;
    BattleData bd;
    PlayerData pd;
    Effect_ButtonText eft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        weaponID = bd.heroID * 3 + index;
        GetComponent<Button>().onClick.AddListener(BuyWeapon);
        image = this.gameObject;
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        eft = GetComponent<Effect_ButtonText>();
        tips_cost.text = cost+"金币";
        if (pd.money >= cost)
        {
            if (state != 1)
            {
                state = 1;
                eft.mode = 1;
                tips.text = "待解锁";
            }
        }
        else
        {
            if (state != 0)
            {
                state = 0;
                eft.mode = 0;
                tips.text = "金币不足";
            }
        }
        if (pd.weaponList.Contains(weaponID))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (pd.money >= cost)
        {
            if (state != 1)
            {
                state = 1;
                eft.mode = 1;
                tips.text = "待解锁";
            }
        }
        else
        {
            if (state != 0)
            {
                state = 0;
                eft.mode = 0;
                tips.text = "金币不足";
            }
        }
    }

    void BuyWeapon()
    {
        if (pd.money >= cost)
        {
            pd.money -= cost;
            pd.weaponList.Add(weaponID);
            uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
            weapon.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
