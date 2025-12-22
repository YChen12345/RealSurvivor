using UnityEngine;
using UnityEngine.UI;

public class Battle_EnemyFade : MonoBehaviour
{
    public float alpha;
    Color c;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (alpha <= 0.01)
        {
            alpha = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= Time.deltaTime*0.8f;
        c = this.gameObject.GetComponent<SpriteRenderer>().color;
        c.a = alpha;
        this.gameObject.GetComponent<SpriteRenderer>().color = c;
        if(alpha < 0.3f)
        {
            Destroy(this.gameObject);
        }
    }
}
