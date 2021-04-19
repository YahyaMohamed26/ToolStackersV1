using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CardZoom : MonoBehaviour
{
    public GameObject zoomCard;
    public GameObject zoomCard2;
    public GameObject canvas;
    public GameObject viewer;

    void Awake()
    {
        canvas = GameObject.Find("GameBoard");
        viewer = GameObject.Find("CardViewer");
    }

   

    public void OnHoverEnter()
    {
        zoomCard2 = GameObject.Instantiate(zoomCard, viewer.transform.position, Quaternion.identity);
        zoomCard2.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        zoomCard2.transform.SetParent(canvas.transform, true);

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(230, 350);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard2);;
    }
}
