using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Battle_EffectFigure : MonoBehaviour
{
    public int value;
    public int value_1;
    public int mode;
    public int isDodge;
    public TextMeshProUGUI text_value;
    public float timer;
    Battle_Info data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        if (isDodge == 1)
        {
            text_value.text = "闪避";
            text_value.color = Color.white;
        }
        else
        {
            if (value > 0)
            {
                switch (mode)
                {
                    case 0:
                        if (value_1 > 0)
                        {
                            text_value.text = "<color=#FF0000>-" + value + "</color><color=#00FFFF>-" + value_1 + "</color>";
                        }
                        else
                        {
                            text_value.text = "<color=#FF0000>-" + value + "</color>";
                        }
                        break;
                    case 1:
                        if (value_1 > 0)
                        {
                            text_value.text = "<color=#FF0000>-" + value + "</color><color=#00FFFF>-" + value_1 + "</color>";
                        }
                        else
                        {
                            text_value.text = "<color=#FF0000>-" + value + "</color>";
                        }
                        text_value.fontStyle = FontStyles.Bold;
                        break;
                    case 2:
                        text_value.text = "-" + value;
                        text_value.color = Color.white;
                        break;
                    case 3:
                        text_value.text = "-" + value;
                        text_value.color = Color.white;
                        text_value.fontStyle = FontStyles.Bold;
                        break;
                }

            }
            else if (value < 0)
            {
                text_value.text = "+" + (-value);
                text_value.color = Color.green;
            }
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
