using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIOnHoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Vector3 cachedScale;
    Vector3 cachedPosition;
    private GameObject zoomCard;
    public GameObject canvas;
    public GameObject viewer;
    void Start()
    {
        cachedScale = transform.localScale;
        canvas = GameObject.Find("Canvas");
        viewer = GameObject.Find("CardViewer");
        //cachedPosition = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        zoomCard = Instantiate(gameObject, viewer.transform.position, Quaternion.identity);
        //zoomCard.transform.Rotate(0, 0, -90);
        zoomCard.transform.SetParent(canvas.transform, true);

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        if(Screen.height == 1080 && Screen.width == 1920)
        {
            rect.sizeDelta = viewer.GetComponent<RectTransform>().sizeDelta;
        }
        else
        {
            rect.sizeDelta = new Vector2(240, 308);
        }
        

        //transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //transform.position = new Vector3(cachedPosition.x, cachedPosition.y + 10f, cachedPosition.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(zoomCard);
        //transform.localScale = cachedScale;
        //transform.SetAsFirstSibling();
        //transform.position = cachedPosition;
    }
}
