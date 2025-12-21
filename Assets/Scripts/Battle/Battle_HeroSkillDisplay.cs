using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battle_HeroSkillDisplay : MonoBehaviour
{
    IUF uf = new Functions();
    public List<GameObject> template;
    public GameObject weaponSkill;
    public GameObject unequipped;
    public GameObject locked;
    public Battle_Info data;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
        GameObject w0 = GameObject.Instantiate(weaponSkill, weaponSkill.transform.parent);
        w0.GetComponent<Battle_HeroSkill>().index = 5;
        w0.GetComponent<Battle_HeroSkill>().kind = 0;
        w0.GetComponent<Battle_HeroSkill>().cid = data.bd.weaponID;
        w0.transform.position = template[5].transform.position;
        w0.SetActive(true);
        for (int i = 0; i < template.Count-1; i++)
        {
            if (i < data.bd.WeaponCardList.Count)
            {
                GameObject w = GameObject.Instantiate(weaponSkill, weaponSkill.transform.parent);
                w.GetComponent<Battle_HeroSkill>().index = i;
                w.GetComponent<Battle_HeroSkill>().kind = 1;
                w.GetComponent<Battle_HeroSkill>().cid = data.bd.WeaponCardList[i];
                w.transform.position = template[i].transform.position;
                w.SetActive(true);
            }
            else if(i<= data.bd.weaponLimit)
            {
                GameObject uneq = GameObject.Instantiate(unequipped, unequipped.transform.parent);
                uneq.transform.position = template[i].transform.position;
                uneq.SetActive(true);
            }
            else
            {
                GameObject l = GameObject.Instantiate(locked, locked.transform.parent);
                l.transform.position = template[i].transform.position;
                l.SetActive(true);
            }
          
        }
    }
}
