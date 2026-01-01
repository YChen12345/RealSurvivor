using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HeroChoose_Hero : MonoBehaviour
{
    public GameObject loadingPage;
    public int heroID;
    GameObject image;
    IUF uf;
    IAnim anim = new UIAnimationPlayer();
    BattleData bd;
    PlayerData pd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        //bd = uf.LoadStructFromJson<BattleData>("Data/BattleData");
        GetComponent<Button>().onClick.AddListener(ChooseHero);
        image = this.gameObject;
        image.GetComponent<Image>().sprite= uf.LoadResource<Sprite>("HeroCard", heroID);
        anim.SetFrameTime(0.1f);
        anim.SetSprites("HeroCardAnim/" + heroID);
        pd = uf.LoadStructFromJson<PlayerData>("Data/PlayerData");
        if (!pd.heroList.Contains(heroID))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        anim.AnimPlay(this.gameObject, 0, Time.deltaTime);
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
