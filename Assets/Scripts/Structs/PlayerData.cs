using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct PlayerData
{
    public int money;
    public List<int> heroList;
    public List<int> weaponList;
    public List<int> levelList;
    /// <summary>
    public float volume;
    public float sound;
    public bool fullscreen;
    public int resolution;
    public int languageID;
    /// </summary>

    public void Init()
    {
        fullscreen = true;
        volume = 0.6f;
        sound = 0.6f;
        resolution = 0;
        languageID = 0;
        money = 360;
        heroList = new List<int>() { 0 };
        weaponList = new List<int>() { 0,3,6,9 };
        levelList = new List<int>() { 0,0,0,0 };
    }
}
