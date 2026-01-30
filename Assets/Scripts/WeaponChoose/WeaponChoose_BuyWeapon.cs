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
    Effect_ButtonText eft;
    public WeaponChoose_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("WeaponChoose").GetComponent<WeaponChoose_Info>();
        weaponID = data.bd.heroID * 3 + index;
        cost = index * 300;
        GetComponent<Button>().onClick.AddListener(BuyWeapon);
        image = this.gameObject;
        image.GetComponent<Image>().sprite = uf.LoadResource<Sprite>("WeaponCard", weaponID);
        eft = GetComponent<Effect_ButtonText>();
        tips_cost.text = cost+"钻石";
        if (data.pd.money >= cost)
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
                tips.text = "钻石不足";
            }
        }
        if (data.pd.weaponList.Contains(weaponID))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (data.pd.money >= cost)
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
                tips.text = "钻石不足";
            }
        }
    }

    void BuyWeapon()
    {
        if (data.pd.money >= cost)
        {
            data.pd.money -= cost;
            data.pd.weaponList.Add(weaponID);
            uf.SaveStructToJson<PlayerData>(data.pd, "Data/PlayerData");
            weapon.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
