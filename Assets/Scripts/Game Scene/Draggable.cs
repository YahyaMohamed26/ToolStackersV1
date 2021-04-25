using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    private bool isDragging;
    public string originalParent;

    private bool CanPickUp()
    {
        if (!TurnSystem.isPlayer1Turn)
        {
            return false;
        }

        if (isDragging)
        {
            return true;
        }

        if (transform.parent == GameObject.Find("Hand").transform || transform.parent == GameObject.Find("Discarded Player 4").transform)
        {
            if(PlayerDeck.hasDrewCard && transform.parent == GameObject.Find("Discarded Player 4").transform)
            {
                return false;
            }
            return true;
        }
        return false;
    }

    public void OnBeginDrag(PointerEventData evenData)
    {
        if (CanPickUp())
        {
            originalParent = transform.gameObject.GetComponent<ThisCard>().owner;
            Debug.Log("OnBeginDrag");
            isDragging = true;
            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeholderParent = parentToReturnTo;
            this.transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (CanPickUp())
        {
            this.transform.position = eventData.position;
            if (placeholder.transform.parent != placeholderParent)
            {
                placeholder.transform.SetParent(placeholderParent);
            }

            int newSiblingsIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingsIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingsIndex)
                    {
                        newSiblingsIndex--;
                    }
                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingsIndex);
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (CanPickUp())
        {
            
            if (originalParent == "Discarded1" || originalParent == "Discarded2" || originalParent == "Discarded3" || originalParent == "Discarded4")
            {
                originalParent = "Discarded";
            }
            if (TurnSystem.isPlayer1Turn && PlayerDeck.hasDiscardedCard && GameObject.Find("Discarded Player 1").transform.childCount > 1)
            {
                this.transform.SetParent(GameObject.Find("Hand").transform);
                Destroy(placeholder);
                return;
            }
            else if(TurnSystem.isPlayer2Turn && PlayerDeck.hasDiscardedCard && GameObject.Find("Discarded Player 2").transform.childCount > 1)
            {
                this.transform.SetParent(GameObject.Find("Hand2").transform);
                Destroy(placeholder);
                return;
            }
            else if (TurnSystem.isPlayer3Turn && PlayerDeck.hasDiscardedCard && GameObject.Find("Discarded Player 3").transform.childCount > 1)
            {
                this.transform.SetParent(GameObject.Find("Hand3").transform);
                Destroy(placeholder);
                return;
            }
            else if (TurnSystem.isPlayer4Turn && PlayerDeck.hasDiscardedCard && GameObject.Find("Discarded Player 4").transform.childCount > 1)
            {
                this.transform.SetParent(GameObject.Find("Hand4").transform);
                Destroy(placeholder);
                return;
            }
            else
            {
                this.transform.SetParent(parentToReturnTo);
            }
            //transform.rotation = parentToReturnTo.rotation;
            
            PlayerPhoton mainPlayer = null;
            foreach (PlayerPhoton player in FindObjectsOfType<PlayerPhoton>())
            {
                if (player.photonView.IsMine)
                {
                    mainPlayer = player;
                    break;
                }
            }

            switch (parentToReturnTo.name)
            {
                case "PM1":
                    mainPlayer.DropCard("PM", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "VC1":
                    mainPlayer.DropCard("VC", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "CN1":
                    mainPlayer.DropCard("CN", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "CR1":
                    mainPlayer.DropCard("CR", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "IT1":
                    mainPlayer.DropCard("IT", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "Discarded Player 1":
                    mainPlayer.DropCard("Discarded Player", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType);
                    break;
                case "Hand":
                    mainPlayer.DropCard("Hand", GetComponent<ThisCard>().cardIndex, GetComponent<ThisCard>().cardType, originalParent);
                    break;
            }

            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            Destroy(placeholder);
        }
    }
}
