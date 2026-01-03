using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Player : MonoBehaviour
{
    Battle_Info data;
    IUF uf;
    IAnim animplayer = new AnimationPlayer();
    public GameObject displayPage;
    public GameObject avatar;
    public GameObject effectFigure;
    public GameObject weaponCenter;
    public GameObject weapon;
    public HeroData hd;
    public HeroData hd_;
    public HeroData hd_last;

    float dis;
    
    public List<float> weapon_cd=new List<float>() {1,1,1,1,1,1 };
    public int beDodge;
    void Start()
    {
        dis = 0.5f;
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        animplayer.SetFrameTime(0.05f);
        string rootRoute = "RoleAnim/" + data.bd.heroID+"/";
        animplayer.SetSprites(rootRoute + "Stay");
        animplayer.SetSprites(rootRoute + "Move");
        avatar.GetComponent<SpriteRenderer>().sprite= uf.LoadResource<Sprite>("Role", data.bd.heroID);
        float height = uf.Area(avatar).height/2;
        avatar.transform.localPosition = new Vector2(0, height* avatar.transform.localScale.y);
        effectFigure.transform.localPosition = new Vector2(0, 2.2f*height * avatar.transform.localScale.y);
        weaponCenter.transform.localPosition = avatar.transform.localPosition;
        weaponCenter.SetActive(true);
        //hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        //hd.init();////////////////////
        hd = data.hd;
        hd_ = hd;
        hd_last = hd_;
        initWeapon();
        displayPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dead();
        BeDodge();
        BeHurt();
        BeHeal();
    }
    void Move()
    {
        uf.MoveByKey(this.gameObject, hd_.speed, uf.GetKeyState());
        uf.MoveLimitation(this.gameObject, data.map_width, data.map_height, Vector2.zero);
        uf.FaceToMoveDir(this.gameObject,avatar,1);
        if (GetComponent<Rigidbody2D>().linearVelocity.magnitude < 0.01f)
        {
            animplayer.AnimPlay(avatar, 0, Time.deltaTime);
        }
        else
        {
            animplayer.AnimPlay(avatar, 1, Time.deltaTime);
        }     
    }
    void BeHurt()
    {
        if (hd_last.blood > hd_.blood)
        {
            int hurtvalue = hd_last.blood - hd_.blood;
            int hurtvalue_1 = hd_last.defence - hd_.defence;
            int df = hd_last.defence;
            hd_last.blood = hd_.blood;
            hd_last.defence = hd_.defence;
            GameObject f = GameObject.Instantiate(effectFigure, effectFigure.transform.position, Quaternion.identity);
            f.transform.parent = null;
            f.GetComponent<Battle_EffectFigure>().value = hurtvalue;
            if (df > 0)
            {
                f.GetComponent<Battle_EffectFigure>().value_1 = hurtvalue_1;
                f.GetComponent<Battle_EffectFigure>().mode = 0;
            }
            else
            {
                f.GetComponent<Battle_EffectFigure>().mode = 2;
            }
            f.SetActive(true);
        }
    }
    void BeDodge()
    {
        if (beDodge==1)
        {
            beDodge = 0;
            GameObject f = GameObject.Instantiate(effectFigure, effectFigure.transform.position, Quaternion.identity);
            f.transform.parent = null;
            f.GetComponent<Battle_EffectFigure>().isDodge = 1;
            f.SetActive(true);
        }
    }

    void BeHeal()
    {
        if (hd_last.blood < hd_.blood)
        {
            int hurtvlaue = hd_last.blood - hd_.blood;
            hd_last.blood = hd_.blood;
            GameObject f = GameObject.Instantiate(effectFigure, effectFigure.transform.position, Quaternion.identity);
            f.transform.parent = null;
            f.GetComponent<Battle_EffectFigure>().value = hurtvlaue;
            f.SetActive(true);
        }
    }
    void initWeapon()
    {
        int weaponCount = data.bd.WeaponCardList.Count + 1;
        GameObject w0 = GameObject.Instantiate(weapon,weapon.transform.parent);
        w0.GetComponent<Battle_PlayerWeapon>().index = 5;
        w0.GetComponent<Battle_PlayerWeapon>().kind = 0;
        w0.GetComponent<Battle_PlayerWeapon>().weaponID = data.bd.weaponID;
        w0.transform.localPosition = uf.RotatedVector2(Vector2.up, 0)*dis;
        w0.SetActive(true);
        for (int i = 0; i < data.bd.WeaponCardList.Count; i++)
        {
            GameObject w = GameObject.Instantiate(weapon, weapon.transform.parent);
            w.GetComponent<Battle_PlayerWeapon>().index = i;
            w.GetComponent<Battle_PlayerWeapon>().kind = 1;
            w.GetComponent<Battle_PlayerWeapon>().weaponID = data.bd.WeaponCardList[i];
            w.transform.localPosition = uf.RotatedVector2(Vector2.up, (360/weaponCount) * (i+1))*dis;
            w.SetActive(true);
        }
    }
    void Dead()
    {
        if (hd_.blood <= 0)
        {
            data.dead = 1;
            hd_.speed = 0;
        }
    }
}
