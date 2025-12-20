using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponChoose_Hero : MonoBehaviour
{
    public int heroID;
    public TextMeshProUGUI hero_name;
    public TextMeshProUGUI hero_content;
    GameObject image;
    IUF uf;
    BattleData bd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        heroID = bd.heroID;
        image = this.gameObject;
        image.GetComponent<Image>().sprite= uf.LoadResource<Sprite>("HeroCard", heroID);
    }
}
