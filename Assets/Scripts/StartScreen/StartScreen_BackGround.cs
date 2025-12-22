using UnityEngine;

public class StartScreen_BackGround : MonoBehaviour
{
    IAnim animplayer = new UIAnimationPlayer();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animplayer.SetFrameTime(0.05f);
        animplayer.SetSprites("BackGround/StartScreen");
    }

    // Update is called once per frame
    void Update()
    {
        animplayer.AnimPlay(this.gameObject, 0, Time.deltaTime);
    }
}
