using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class AssemblyCell : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public Vector2 position;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Drop");
            GameObject block = eventData.pointerDrag;
            block.transform.parent = transform;
            block.GetComponent<RectTransform>().localPosition = Vector2.zero;
            block.GetComponent<DragNDrop>().isInstalled = true;
        }
        
    }
}
