using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviourPun
{
    public static bool isPlayer1Turn;
    public static bool isPlayer2Turn;
    public static bool isPlayer3Turn;
    public static bool isPlayer4Turn;

    public GameObject DrawButton; 
    public GameObject DrawEventButton;
    public GameObject Player1Name;
    public GameObject Player2Name;
    public GameObject Player3Name;
    public GameObject Player4Name;

    public GameObject turnPanel;

    // Start is called before the first frame update
    void Start()
    {
        Player1Name = GameObject.Find("Player 1 Name Block");
        Player2Name = GameObject.Find("Player 2 Name Block");
        Player3Name = GameObject.Find("Player 3 Name Block");
        Player4Name = GameObject.Find("Player 4 Name Block");
        Player1Name.GetComponent<Image>().color = Color.yellow;
    }

    public void leave()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1Turn)
        {
            Player1Name.GetComponent<Image>().color = Color.yellow;
            Player2Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player3Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player4Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            turnPanel.SetActive(false);
        }   
        else if (isPlayer2Turn)
        {
            Player1Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player3Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player4Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player2Name.GetComponent<Image>().color = Color.yellow;
            turnPanel.SetActive(true);
        }   
        else if (isPlayer3Turn)
        {
            Player1Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player2Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player4Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player3Name.GetComponent<Image>().color = Color.yellow;
            turnPanel.SetActive(true);
        }   
        else if(isPlayer4Turn)
        {
            Player1Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player2Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player3Name.GetComponent<Image>().color = new Color32(193, 224, 231, 255);
            Player4Name.GetComponent<Image>().color = Color.yellow;
            turnPanel.SetActive(true);
        }   
    }

    public void EndTurn()
    {
        GetComponent<PhotonView>().RPC("RpcEndTurn", RpcTarget.All);
    }

    //[ClientRpc]
    [PunRPC]
    public void RpcEndTurn()
    {
        if (isPlayer1Turn)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                isPlayer1Turn = false;
                isPlayer2Turn = true;
            }
            PlayerDeck.hasDrewCard = false;
            PlayerDeck.hasDiscardedCard = false;
            DrawButton.GetComponent<Button>().interactable = true;
            DrawEventButton.GetComponent<Button>().interactable = true;
            Player1Name.GetComponent<Image>().color = Color.black;
            if (PlayerDeck.eventCard != null && PlayerDeck.eventCard.tag != "Upgrade")
            {
                Destroy(PlayerDeck.eventCard);
                PlayerDeck.eventDeckSize++;
                int x = Random.Range(0, PlayerDeck.eventDeckSize);
                Card temp = PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1];
                PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1] = PlayerDeck.staticEventDeck[x];
                PlayerDeck.staticEventDeck[x] = temp;
                ThisCard.numberOfCardsInEventDeck++;
            }
            GameObject discarded = GameObject.Find("Discarded Player 4");
            if (discarded.transform.childCount > 0)
            {
                Destroy(discarded.transform.GetChild(0).gameObject);
            }
        }
        else if (isPlayer2Turn)
        {
            isPlayer2Turn = false;
            if (PhotonNetwork.CurrentRoom.PlayerCount >= 3)
            {
                isPlayer3Turn = true;
            }
            else
            {
                isPlayer1Turn = true;
            }
            PlayerDeck.hasDrewCard = false;
            PlayerDeck.hasDiscardedCard = false;
            DrawButton.GetComponent<Button>().interactable = true;
            DrawEventButton.GetComponent<Button>().interactable = true;
            Player2Name.GetComponent<Image>().color = Color.black;
            if (PlayerDeck.eventCard != null && PlayerDeck.eventCard.tag != "Upgrade")
            {
                Destroy(PlayerDeck.eventCard);
                PlayerDeck.eventDeckSize++;
                int x = Random.Range(0, PlayerDeck.eventDeckSize);
                Card temp = PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1];
                PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1] = PlayerDeck.staticEventDeck[x];
                PlayerDeck.staticEventDeck[x] = temp;
                ThisCard.numberOfCardsInEventDeck++;
            }
            GameObject discarded = GameObject.Find("Discarded Player 1");
            if (discarded.transform.childCount > 0)
            {
                Destroy(discarded.transform.GetChild(0).gameObject);
            }
        }
        else if (isPlayer3Turn)
        {
            isPlayer3Turn = false;
            if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                isPlayer4Turn = true;
            }
            else
            {
                isPlayer1Turn = true;
            }
            PlayerDeck.hasDrewCard = false;
            PlayerDeck.hasDiscardedCard = false;
            DrawButton.GetComponent<Button>().interactable = true;
            DrawEventButton.GetComponent<Button>().interactable = true;
            Player3Name.GetComponent<Image>().color = Color.black;
            if (PlayerDeck.eventCard != null && PlayerDeck.eventCard.tag != "Upgrade")
            {
                Destroy(PlayerDeck.eventCard);
                PlayerDeck.eventDeckSize++;
                int x = Random.Range(0, PlayerDeck.eventDeckSize);
                Card temp = PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1];
                PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1] = PlayerDeck.staticEventDeck[x];
                PlayerDeck.staticEventDeck[x] = temp;
                ThisCard.numberOfCardsInEventDeck++;
            }
            GameObject discarded = GameObject.Find("Discarded Player 2");
            if (discarded.transform.childCount > 0)
            {
                Destroy(discarded.transform.GetChild(0).gameObject);
            }
        }
        else
        {
            isPlayer4Turn = false;
            isPlayer1Turn = true;
            PlayerDeck.hasDrewCard = false;
            PlayerDeck.hasDiscardedCard = false;
            DrawButton.GetComponent<Button>().interactable = true;
            DrawEventButton.GetComponent<Button>().interactable = true;
            Player4Name.GetComponent<Image>().color = Color.black;
            if (PlayerDeck.eventCard != null && PlayerDeck.eventCard.tag != "Upgrade")
            {
                Destroy(PlayerDeck.eventCard);
                PlayerDeck.eventDeckSize++;
                int x = Random.Range(0, PlayerDeck.eventDeckSize);
                Card temp = PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1];
                PlayerDeck.staticEventDeck[PlayerDeck.eventDeckSize - 1] = PlayerDeck.staticEventDeck[x];
                PlayerDeck.staticEventDeck[x] = temp;
                ThisCard.numberOfCardsInEventDeck++;
            }
            GameObject discarded = GameObject.Find("Discarded Player 3");
            if (discarded.transform.childCount > 0)
            {
                Destroy(discarded.transform.GetChild(0).gameObject);
            }
        }
    }

}
