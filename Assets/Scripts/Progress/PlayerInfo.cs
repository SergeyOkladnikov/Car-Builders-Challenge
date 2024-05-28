using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public int level;
    public float levelProgess;
    public int money;
    public int chips;
    public int maxBoosts = 10;
    public int boosts;
    public int currentLoc;
}
