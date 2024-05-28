using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    public void LoadLevel(string levelName)
    {
        GameObject levelPrefab = (GameObject)Resources.Load($"prefabs/levels/{levelName}");
        GameObject level = Instantiate(levelPrefab);
        Canvas background = level.GetComponentInChildren<Canvas>();
        background.worldCamera = _camera;
    }

    //DUMMY
    private void OnEnable()
    {
        LoadLevel("testLevel1");
    }
}
