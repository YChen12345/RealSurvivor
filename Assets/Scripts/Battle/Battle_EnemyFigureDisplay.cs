using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Battle_EnemyFigureDisplay : MonoBehaviour
{
    public GameObject blood_line;
    public GameObject defence_line;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blood_line.transform.localScale = new Vector3(1, 1, 1);
        defence_line.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        blood_line.transform.localScale = 
            new Vector3((float)GetComponent<Battle_Enemy>().enemy.blood / (float)GetComponent<Battle_Enemy>().enemyfigure.blood, 1, 1);
        defence_line.transform.localScale =
            new Vector3((float)GetComponent<Battle_Enemy>().enemy.defence / (float)GetComponent<Battle_Enemy>().enemyfigure.defence, 1, 1);
    }
}
