using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartInfo
{
    public string name;
    public string bindingType;
    public string level;
    public string type;
    public bool isOccupied = false;

    public PartInfo(string name, string bindingType, string level, string type)
    {
        this.name = name;
        this.bindingType = bindingType;
        this.level = level;
        this.type = type;
    }
}

