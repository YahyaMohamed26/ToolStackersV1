using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerPhoton : MonoBehaviourPun
{
    public GameObject Hand, Hand2, Hand3, Hand4;

    [HideInInspector]
    public bool hasDrewOnce;

    private void Start()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("SyncName", RpcTarget.Others, PhotonNetwork.NickName, photonView.ViewID);
            GameObject.Find("Player 1 Name").GetComponent<Text>().text = PhotonNetwork.NickName;
            GameObject.Find("Discard 1 Text").GetComponent<Text>().text = PhotonNetwork.NickName + "\nDiscarded Cards";
            if(photonView.ViewID == 1001)
            {
                GameObject.Find("Character 1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 1");
            }
            else if (photonView.ViewID == 2001)
            {
                GameObject.Find("Character 1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 2");
            }
            else if (photonView.ViewID == 3001)
            {
                GameObject.Find("Character 1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 3");
            }
            else if (photonView.ViewID == 4001)
            {
                GameObject.Find("Character 1").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 4");
            }
        }
    }

    [PunRPC]
    private void SyncName(string name, int id)
    {
        int myIndex = 0;

        Debug.Log(name + " " + id);

        foreach (PlayerPhoton player in FindObjectsOfType<PlayerPhoton>())
        {
            if (player.photonView.IsMine)
            {
                myIndex = player.photonView.ViewID;
                break;
            }
        }

        Debug.Log(myIndex);

        switch (myIndex)
        {
            case 1001:
                TurnSystem.isPlayer1Turn = true;
                TurnSystem.isPlayer2Turn = false;
                TurnSystem.isPlayer3Turn = false;
                TurnSystem.isPlayer4Turn = false;
                switch (id)
                {
                    case 2001:
                        GameObject.Find("Player 2 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 2 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 2");
                        break;
                    case 3001:
                        GameObject.Find("Player 3 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 3 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 3");
                        break;
                    case 4001:
                        GameObject.Find("Player 4 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 4 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 4").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 4");
                        break;
                }
                break;
            case 2001:
                TurnSystem.isPlayer1Turn = false;
                TurnSystem.isPlayer2Turn = false;
                TurnSystem.isPlayer3Turn = false;
                TurnSystem.isPlayer4Turn = true;
                switch (id)
                {
                    case 1001:
                        GameObject.Find("Player 4 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 4 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 4").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 1");
                        break;
                    case 3001:
                        GameObject.Find("Player 2 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 2 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 3");
                        break;
                    case 4001:
                        GameObject.Find("Player 3 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 3 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 4");
                        break;
                }
                break;
            case 3001:
                TurnSystem.isPlayer1Turn = false;
                TurnSystem.isPlayer2Turn = false;
                TurnSystem.isPlayer3Turn = true;
                TurnSystem.isPlayer4Turn = false;
                switch (id)
                {
                    case 1001:
                        GameObject.Find("Player 3 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 3 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 1");
                        break;
                    case 2001:
                        GameObject.Find("Player 4 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 4 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 4").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 2");
                        break;
                    case 4001:
                        GameObject.Find("Player 2 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 2 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 4");
                        break;
                }
                break;
            case 4001:
                TurnSystem.isPlayer1Turn = false;
                TurnSystem.isPlayer2Turn = true;
                TurnSystem.isPlayer3Turn = false;
                TurnSystem.isPlayer4Turn = false;
                switch (id)
                {
                    case 1001:
                        GameObject.Find("Player 2 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 2 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 1");
                        break;
                    case 2001:
                        GameObject.Find("Player 3 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 3 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 2");
                        break;
                    case 3001:
                        GameObject.Find("Player 4 Name").GetComponent<Text>().text = name;
                        GameObject.Find("Discard 4 Text").GetComponent<Text>().text = name + "\nDiscarded Cards";
                        GameObject.Find("Character 4").GetComponent<Image>().sprite = Resources.Load<Sprite>("Ch 3");
                        break;
                }
                break;
        }
    }

  /**  public void CmdDealCards()
    {
        for (int i = 0; i < 5; i++)
        {
            GameManage.sToolDeckSize--;
            Debug.Log(GameManage.sToolDeckSize);
            // string cardName = PlayerManager.sToolCardsDeck[PlayerManager.sToolDeckSize].name;
            // Debug.Log("HEY " + cardName);

            string cardName = GameManage.sToolCardsDeck[GameManage.sToolDeckSize].name;


            Hand = GameObject.Find("Hand");

            PhotonNetwork.Instantiate(cardName, transform.position, transform.rotation);
           // pcard1.transform.SetParent(Hand.transform, false);
        }
    } 
  */
    public void DropCard(string parentName, int cardIndex, string cardType, string oldParent = "None")
    {
        photonView.RPC("RpcDropCard", RpcTarget.Others, parentName, cardIndex, cardType, oldParent);
    }

    private void Update()
    {
        if (photonView.IsMine && PlayerDeck.p1score == 10)
        {
            PlayerDeck.endPanels.SetActive(true);
            PlayerDeck.panelTexts.GetComponent<Text>().text = "Congrats " + GameObject.Find("Player 1 Name").GetComponent<Text>().text + " you have won!";
        }
        else if (TurnSystem.isPlayer2Turn && PlayerDeck.p2score == 10)
        {
            PlayerDeck.endPanels.SetActive(true);
            PlayerDeck.panelTexts.GetComponent<Text>().text = GameObject.Find("Player 2 Name").GetComponent<Text>().text + " have won!";
        }
        else if (TurnSystem.isPlayer3Turn && PlayerDeck.p3score == 10)
        {
            PlayerDeck.endPanels.SetActive(true);
            PlayerDeck.panelTexts.GetComponent<Text>().text = GameObject.Find("Player 3 Name").GetComponent<Text>().text + " have won!";
        }
        else if (TurnSystem.isPlayer4Turn && PlayerDeck.p4score == 10)
        {
            PlayerDeck.endPanels.SetActive(true);
            PlayerDeck.panelTexts.GetComponent<Text>().text = GameObject.Find("Player 4 Name").GetComponent<Text>().text + " have won!";
        }
    }

    [PunRPC]
    private void RpcDropCard(string parentType, int cardIndex, string cardType, string old)
    {
        string parentName = "";
        string cardName = "";

        if (TurnSystem.isPlayer1Turn)
        {
            if (parentType == "Discarded Player")
            {
                parentName = parentType + " 1";
                cardName = "Player 1 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old != "Hand")
            {
                parentName = parentType;
                cardName = "Player 4 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old == "Hand")
            {
                parentName = parentType;
                cardName = "Player 1 " + cardType + " Card " + cardIndex.ToString();
            }
            else
            {
                parentName = parentType + "1";
                cardName = "Player 1 " + cardType + " Card " + cardIndex.ToString();
            }

        }
        else if (TurnSystem.isPlayer2Turn)
        {
            if (parentType == "Discarded Player")
            {
                parentName = parentType + " 2";
                cardName = "Player 2 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old != "Hand")
            {
                parentName = parentType + "2";
                cardName = "Player 1 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old == "Hand")
            {
                parentName = parentType + "2";
                cardName = "Player 2 " + cardType + " Card " + cardIndex.ToString();
            }
            else
            {
                parentName = parentType + "2";
                cardName = "Player 2 " + cardType + " Card " + cardIndex.ToString();
            }

        }
        else if (TurnSystem.isPlayer3Turn)
        {
            if (parentType == "Discarded Player")
            {
                parentName = parentType + " 3";
                cardName = "Player 3 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old != "Hand")
            {
                parentName = parentType + "3";
                cardName = "Player 2 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old == "Hand")
            {
                parentName = parentType + "3";
                cardName = "Player 3 " + cardType + " Card " + cardIndex.ToString();
            }
            else
            {
                parentName = parentType + "3";
                cardName = "Player 3 " + cardType + " Card " + cardIndex.ToString();
            }
        }
        else if (TurnSystem.isPlayer4Turn)
        {
            if (parentType == "Discarded Player")
            {
                parentName = parentType + " 4";
                cardName = "Player 4 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old != "Hand")
            {
                parentName = parentType + "4";
                cardName = "Player 3 " + cardType + " Card " + cardIndex.ToString();
            }
            else if (parentType == "Hand" && old == "Hand")
            {
                parentName = parentType + "4";
                cardName = "Player 4 " + cardType + " Card " + cardIndex.ToString();
            }
            else
            {
                parentName = parentType + "4";
                cardName = "Player 4 " + cardType + " Card " + cardIndex.ToString();
            }
        }

        Transform parent = null;
        Transform card = null;

        if (GameObject.Find(parentName) != null)
        {
            parent = GameObject.Find(parentName).transform;
        }
        else
        {
            Debug.LogError(parentName + " not found");
        }

        if (GameObject.Find(cardName) != null)
        {
            GameObject c = GameObject.Find(cardName);
            if (parentType == "Hand")
            {
                if (TurnSystem.isPlayer1Turn)
                {
                    c.name = "Player 1 Normal Card " + cardIndex.ToString();
                }
                else if (TurnSystem.isPlayer2Turn)
                {
                    c.name = "Player 2 Normal Card " + cardIndex.ToString();
                }
                else if (TurnSystem.isPlayer3Turn)
                {
                    c.name = "Player 3 Normal Card " + cardIndex.ToString();
                }
                else if (TurnSystem.isPlayer4Turn)
                {
                    c.name = "Player 4 Normal Card " + cardIndex.ToString();
                }
            }

            card = c.transform;
        }
        else
        {
            Debug.LogError(cardName + " not found");
        }

        if (parent && card)
        {
            card.SetParent(parent);
            card.rotation = parent.rotation;
        }
    }
}
