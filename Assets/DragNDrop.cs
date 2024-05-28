using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public bool isInstalled = false;
    [SerializeField]
    private Canvas _canvas;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        isInstalled = false;
        _canvasGroup.blocksRaycasts = false;
        if (transform.parent.GetComponent<BlockCell>() != null)
        {
            DragNDrop staying = Instantiate(this, this.transform.parent);
            staying._canvas = _canvas;
            staying._canvasGroup.blocksRaycasts = true;
        }
        transform.parent = _canvas.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        if (!isInstalled)
        {
            Destroy(gameObject);
        }
        _canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

}
