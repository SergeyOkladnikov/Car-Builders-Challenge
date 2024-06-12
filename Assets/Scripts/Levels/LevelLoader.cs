using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Assembly _assembly;
    public void LoadLevel(string levelName)
    {
        GameObject levelPrefab = (GameObject)Resources.Load($"prefabs/levels/{levelName}");
        GameObject level = Instantiate(levelPrefab);

        Canvas background = level.GetComponentInChildren<Canvas>();
        background.worldCamera = _camera;

        //Temporary stub for tests
        PartInfo[,] parts = new PartInfo[,] {
            { new PartInfo("Driver", "top", "debug", "driver"),
              null,
              new PartInfo("Weapon", "top", "debug", "weapon")
            },
            { new PartInfo("Struct", "all", "debug", "construction"),
              new PartInfo("Struct", "all", "debug", "construction"),
              new PartInfo("Struct", "all", "debug", "construction")
            },
            {
              new PartInfo("Suspension", "wheels", "debug", "suspension"),
              null,
              new PartInfo("Suspension", "wheels", "debug", "suspension")
            },
            {
              new PartInfo("Wheel", "joints", "debug", "wheel"),
              null,
              new PartInfo("Wheel", "joints", "debug", "wheel")
            }
        };
        _assembly.Build(parts, new Vector2(-14, 2), "Test");
        GameObject bot = (GameObject)Resources.Load($"prefabs/Enemy");
        bot = Instantiate(bot, new Vector3(14, 2, 0), new Quaternion());

    }

    //DUMMY
    /*private void OnEnable()
    {
        LoadLevel("testLevel1");
    }*/
}
