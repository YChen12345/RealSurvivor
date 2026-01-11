using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class HeroChoose_Hero : MonoBehaviour
{
    public GameObject loadingPage;
    public int heroID;
    GameObject image;
    public GameObject frame;
    public TextMeshProUGUI hero_name;
    IUF uf;
    IAnim anim = new UIAnimationPlayer();
    BattleData bd;
    PlayerData pd;
    IAnim anim_frame = new UIAnimationPlayer();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        anim_frame.SetFrameTime(0.1f);
        anim_frame.SetSprites("HeroFrame");
        //bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        Config_D_hero d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        GetComponent<Button>().onClick.AddListener(ChooseHero);
        image = this.gameObject;
        image.GetComponent<Image>().sprite= uf.LoadResource<Sprite>("HeroCard", heroID);
        anim.SetFrameTime(0.1f);
        anim.SetSprites("HeroCardAnim/" + heroID);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        hero_name.text = d_hero.heroDesList[heroID].hero_name;
        if (!pd.heroList.Contains(heroID))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        anim.AnimPlay(this.gameObject, 0, Time.deltaTime);
        anim_frame.AnimPlay(frame, 0, Time.deltaTime);
    }
    void ChooseHero()
    {
        bd.Init();
        bd.heroID = heroID;
        uf.SaveStructToJson<BattleData>(bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "WeaponChoose";
    }
}
