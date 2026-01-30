using UnityEngine;

public class Test_PlayMove : MonoBehaviour
{
    Battle_Info data;
    IUF uf = new Functions();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        uf.MoveByKey(this.gameObject, 3, uf.GetKeyState());
        uf.MoveLimitation(this.gameObject, data.map_width, data.map_height, Vector2.zero);
    }
}
