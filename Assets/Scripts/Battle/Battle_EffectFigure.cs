using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Battle_EffectFigure : MonoBehaviour
{
    public int value;
    public TextMeshProUGUI text_value;
    public float timer;
    Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        if (value > 0)
        {
            text_value.text = "-"+value;
            text_value.color = Color.red;
        }
        else if (value < 0)
        {
            text_value.text = "+" + (-value);
            text_value.color = Color.green;
        }
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            Destroy(this.gameObject);
        }
        if (data.state == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
