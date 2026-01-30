using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class HeroChoose_Hero : MonoBehaviour
{
    public HeroChoose_Info data;
    public GameObject loadingPage;
    public int heroID;
    GameObject image;
    public GameObject frame;
    public TextMeshProUGUI hero_name;
    IUF uf;
    IAnim anim = new UIAnimationPlayer();
    IAnim anim_frame = new UIAnimationPlayer();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("HeroChoose").GetComponent<HeroChoose_Info>();
        anim_frame.SetFrameTime(0.1f);
        anim_frame.SetSprites("HeroFrame");
        //bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        Config_D_hero d_hero = uf.LoadStructFromJson<Config_D_hero>("Config/D/Config_D_hero");
        GetComponent<Button>().onClick.AddListener(ChooseHero);
        image = this.gameObject;
        image.GetComponent<Image>().sprite= uf.LoadResource<Sprite>("HeroCard", heroID);
        anim.SetFrameTime(0.1f);
        anim.SetSprites("HeroCardAnim/" + heroID);
        data.pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        hero_name.text = d_hero.heroDesList[heroID].hero_name;
        if (!data.pd.heroList.Contains(heroID))
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
        data.bd.Init();
        data.bd.heroID = heroID;
        uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
        loadingPage.SetActive(true);
        loadingPage.GetComponent<LoadingPage>().sceneName = "WeaponChoose";
    }
}
