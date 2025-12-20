using System.Collections.Generic;
using UnityEngine;

public class Battle_Player : MonoBehaviour
{
    Battle_Info data;
    IUF uf;
    public GameObject avatar;
    public GameObject weaponCenter;
    public GameObject weapon;
    public HeroData hd;
    public HeroData hd_;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        avatar.GetComponent<SpriteRenderer>().sprite= uf.LoadResource<Sprite>("Role", data.bd.heroID);
        float height = uf.Area(avatar).height/2;
        avatar.transform.localPosition = new Vector2(0, height* avatar.transform.localScale.y);
        weaponCenter.transform.localPosition = new Vector2(0, height * avatar.transform.localScale.y);
        hd = uf.LoadStructFromJson<HeroData>("Data/HeroData");
        hd_ = hd;
        initWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        //uf.MoveByKey(this.gameObject, hd_.speed, uf.GetKeyState());
        uf.MoveByKey(this.gameObject, 3, uf.GetKeyState());
        uf.MoveLimitation(this.gameObject, data.map_width, data.map_height, Vector2.zero);
        uf.FaceToMoveDir(this.gameObject,avatar,1);
    }
    void initWeapon()
    {
        int weaponCount = data.bd.WeaponCardList.Count + 1;
        GameObject w0 = GameObject.Instantiate(weapon,weapon.transform.parent);
        w0.GetComponent<Battle_PlayerWeapon>().index = -1;
        w0.GetComponent<Battle_PlayerWeapon>().weaponID = data.bd.weaponID;
        w0.transform.localPosition = uf.RotatedVector2(Vector2.up, 0);
        w0.SetActive(true);
        for (int i = 0; i < data.bd.WeaponCardList.Count; i++)
        {
            GameObject w = GameObject.Instantiate(weapon, weapon.transform.parent);
            w.GetComponent<Battle_PlayerWeapon>().index = i;
            w.GetComponent<Battle_PlayerWeapon>().weaponID = data.bd.WeaponCardList[i];
            w.transform.localPosition = uf.RotatedVector2(Vector2.up, (360/weaponCount) * (i+1));
            w.SetActive(true);
        }
    }
}
