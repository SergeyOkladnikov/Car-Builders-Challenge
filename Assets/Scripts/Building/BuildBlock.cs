using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlock : MonoBehaviour
{
    [SerializeField]
    public PartInfo partInfo; 

    public BuildBlock(PartInfo partInfoSource)
    {
        partInfo = partInfoSource;
    }
}
