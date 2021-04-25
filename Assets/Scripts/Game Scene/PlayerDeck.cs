using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> eventDeck = new List<Card>();
    public List<Card> container = new List<Card>();

    public static List<Card> player1Cards = new List<Card>();
    public static List<Card> player2Cards = new List<Card>();
    public static List<Card> player3Cards = new List<Card>();
    public static List<Card> player4Cards = new List<Card>();

    public List<Card> player1Cardsp = new List<Card>();
    public List<Card> player2Cardsp = new List<Card>();
    public List<Card> player3Cardsp = new List<Card>();
    public List<Card> player4Cardsp = new List<Card>();

    public static List<Card> player1StackCards = new List<Card>();
    public static List<Card> player2StackCards = new List<Card>();
    public static List<Card> player3StackCards = new List<Card>();
    public static List<Card> player4StackCards = new List<Card>();

    public List<Card> player1StackCardsp = new List<Card>();
    public List<Card> player2StackCardsp = new List<Card>();
    public List<Card> player3StackCardsp = new List<Card>();
    public List<Card> player4StackCardsp = new List<Card>();

    private int x;
    public static int deckSize;
    public static int eventDeckSize;
    public static List<Card> staticDeck = new List<Card>();
    public static List<Card> staticEventDeck = new List<Card>();

    public GameObject CardToHand;
    public GameObject Hand;
    public GameObject Hand2;
    public GameObject Hand3;
    public GameObject Hand4;
    public GameObject PM;
    public GameObject VC;
    public GameObject IT;
    public GameObject CN;
    public GameObject CR;
    public static bool hasDrewCard;
    public static bool hasDiscardedCard;
    public static bool hasDealtCards;
    public GameObject DrawButton;
    public GameObject DrawEventButton;
    public GameObject PerformEventButton;
    public GameObject DealCards;

    public Text player1Score;
    public Text player2Score;
    public Text player3Score;
    public Text player4Score;

    public static int p1score;
    public static int p2score;
    public static int p3score;
    public static int p4score;

    public bool p1has1, p1has2, p1has3, p1has4, p1has5;
    public bool p2has1, p2has2, p2has3, p2has4, p2has5;
    public bool p3has1, p3has2, p3has3, p3has4, p3has5;
    public bool p4has1, p4has2, p4has3, p4has4, p4has5;

    public static string drawType;
    private bool hasCompleteStackP1;
    private bool hasCompleteStackP2;
    private bool hasCompleteStackP3;
    private bool hasCompleteStackP4;

    public GameObject endTurnButton;
    public static GameObject eventCard;

    public int dealCardCallCount;
    public static int cardNo;

    public GameObject endPanel;
    public GameObject panelText;
    public GameObject restartButton;
    public GameObject exitButton;
    public static GameObject endPanels;
    public static GameObject panelTexts;
    public static GameObject restartButtons;
    public static GameObject exitButtons;
    public Text cardCount;

    // Start is called before the first frame update
    void Start()
    {
        cardNo = 1;
        p1score = 0;
        p2score = 0;
        p3score = 0;
        p4score = 0;
        hasCompleteStackP1 = false;
        hasCompleteStackP2 = false;
        hasCompleteStackP3 = false;
        hasCompleteStackP4 = false;
        hasDiscardedCard = false;
        hasDealtCards = false;
        hasDrewCard = false;
        eventCard = null;
        //TurnSystem.isPlayer1Turn = true;
        DrawEventButton.GetComponent<Button>().interactable = false;
        endTurnButton.GetComponent<Button>().interactable = false;
        DrawButton.GetComponent<Button>().interactable = false;
        PerformEventButton.GetComponent<Button>().interactable = false;
        endPanels = endPanel;
        panelTexts = panelText;
        endPanel.SetActive(false);
        endPanels.SetActive(false);

        x = 0;
        cardCount.text = cardNo.ToString();
        deckSize = 44;
        eventDeckSize = 32;
        
        if (PhotonNetwork.IsMasterClient)
        {
            Shuffle();
            for (int i = 0; i < 44; i++)
            {
                deck[i] = CardDatabase.cardsList[x];
                GetComponent<PhotonView>().RPC("SyncDeck", RpcTarget.Others, i, deck[i].id);
                x++;
                if (x == 23)
                {
                   x = 0;
                }
            }
            x = 23;
            for (int i = 0; i < 39; i++)
            {
                eventDeck[i] = CardDatabase.cardsList[x];
                GetComponent<PhotonView>().RPC("EventSyncDeck", RpcTarget.Others, i, eventDeck[i].id);
                x++;
                if (x == 39)
                {
                    x = 23;
                }
            }
        }
        //Shuffle();
        //hasDrewCard = false;
       
       //StartG();
    }

    [PunRPC]
    private void SyncDeck(int deckIndex, int cardIndex)
    {
        deck[deckIndex] = CardDatabase.cardsList[cardIndex];
    }

    [PunRPC]
    private void EventSyncDeck(int deckIndex, int cardIndex)
    {
        eventDeck[deckIndex] = CardDatabase.cardsList[cardIndex];
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;
        staticEventDeck = eventDeck;
        cardCount.text = cardNo.ToString();
        player1Cardsp = player1Cards;
        player2Cardsp = player2Cards;
        player3Cardsp = player3Cards;
        player4Cardsp = player4Cards;

        player1StackCardsp = player1StackCards;
        player2StackCardsp = player2StackCards;
        player3StackCardsp = player3StackCards;
        player4StackCardsp = player4StackCards;

        if (TurnSystem.isPlayer1Turn)
        {
            PM = GameObject.Find("PM1");
            CR = GameObject.Find("CR1");
            CN = GameObject.Find("CN1");
            IT = GameObject.Find("IT1");
            VC = GameObject.Find("VC1");
        }
        else if (TurnSystem.isPlayer2Turn)
        {
            PM = GameObject.Find("PM2");
            CR = GameObject.Find("CR2");
            CN = GameObject.Find("CN2");
            IT = GameObject.Find("IT2");
            VC = GameObject.Find("VC2");
        }
        else if (TurnSystem.isPlayer3Turn)
        {
            PM = GameObject.Find("PM3");
            CR = GameObject.Find("CR3");
            CN = GameObject.Find("CN3");
            IT = GameObject.Find("IT3");
            VC = GameObject.Find("VC3");
        }
        else if (TurnSystem.isPlayer4Turn)
        {
            PM = GameObject.Find("PM4");
            CR = GameObject.Find("CR4");
            CN = GameObject.Find("CN4");
            IT = GameObject.Find("IT4");
            VC = GameObject.Find("VC4");
        }

        if (eventCard == null)
        {
            PerformEventButton.GetComponent<Button>().interactable = false;
        }

        if ((hasDrewCard && !hasDiscardedCard) || !hasDealtCards)
        {
            DrawButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = false;
        }
        else if(hasDiscardedCard && hasDrewCard)
        {
            DrawButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = true;
        }
        else if (!hasDrewCard && hasDealtCards)
        {
            DrawButton.GetComponent<Button>().interactable = true;
            endTurnButton.GetComponent<Button>().interactable = true;
        }

        if (TurnSystem.isPlayer1Turn && hasDealtCards && (GameObject.Find("Discarded Player 1").transform.childCount > 0 || Hand.transform.childCount == 0))
        {
            hasDiscardedCard = true;
        }
        else if(TurnSystem.isPlayer2Turn && hasDealtCards && (GameObject.Find("Discarded Player 2").transform.childCount > 0 || Hand2.transform.childCount == 0))
        {
            hasDiscardedCard = true;
        }
        else if (TurnSystem.isPlayer3Turn && hasDealtCards && (GameObject.Find("Discarded Player 3").transform.childCount > 0 || Hand3.transform.childCount == 0))
        {
            hasDiscardedCard = true;
        }
        else if (TurnSystem.isPlayer4Turn && hasDealtCards && (GameObject.Find("Discarded Player 4").transform.childCount > 0 || Hand4.transform.childCount == 0))
        {
            hasDiscardedCard = true;
        }
        else if(TurnSystem.isPlayer1Turn && Hand.transform.childCount == 1)
        {
            if(Hand.transform.GetChild(0).gameObject.tag == "Event")
            {
                hasDiscardedCard = true;
            }
        }
        else if (TurnSystem.isPlayer2Turn && Hand2.transform.childCount == 1)
        {
            if (Hand2.transform.GetChild(0).gameObject.tag == "Event")
            {
                hasDiscardedCard = true;
            }
        }
        else if (TurnSystem.isPlayer3Turn && Hand3.transform.childCount == 1)
        {
            if (Hand3.transform.GetChild(0).gameObject.tag == "Event")
            {
                hasDiscardedCard = true;
            }
        }
        else if (TurnSystem.isPlayer4Turn && Hand4.transform.childCount == 1)
        {
            if (Hand4.transform.GetChild(0).gameObject.tag == "Event")
            {
                hasDiscardedCard = true;
            }
        }

        for (int i = 0; i < player1StackCardsp.Count; i++)
        {
            if (player1StackCardsp[i].id == 0 || player1StackCardsp[i].id == 1 || player1StackCardsp[i].id == 2 || player1StackCardsp[i].id == 3 || player1StackCardsp[i].id == 4)//CR
                p1has1 = true;

            if (player1StackCardsp[i].id == 5 || player1StackCardsp[i].id == 6 || player1StackCardsp[i].id == 7 || player1StackCardsp[i].id == 8)//VC
                p1has2 = true;

            if (player1StackCardsp[i].id == 9 || player1StackCardsp[i].id == 10 || player1StackCardsp[i].id == 11 || player1StackCardsp[i].id == 12 || player1StackCardsp[i].id == 13)//CN
                p1has3 = true;

            if (player1StackCardsp[i].id == 14 || player1StackCardsp[i].id == 15 || player1StackCardsp[i].id == 16 || player1StackCardsp[i].id == 17)//IT
                p1has4 = true;

            if (player1StackCardsp[i].id == 18 || player1StackCardsp[i].id == 19 || player1StackCardsp[i].id == 20 || player1StackCardsp[i].id == 21 || player1StackCardsp[i].id == 22)//PM
                p1has5 = true;
        }

        for (int i = 0; i < player2StackCardsp.Count; i++)
        {
            if (player2StackCardsp[i].id == 0 || player2StackCardsp[i].id == 1 || player2StackCardsp[i].id == 2 || player2StackCardsp[i].id == 3 || player2StackCardsp[i].id == 4)//CR
                p2has1 = true;
            
            if (player2StackCardsp[i].id == 5 || player2StackCardsp[i].id == 6 || player2StackCardsp[i].id == 7 || player2StackCardsp[i].id == 8)//VC
                p2has2 = true;
            
            if (player2StackCardsp[i].id == 9 || player2StackCardsp[i].id == 10 || player2StackCardsp[i].id == 11 || player2StackCardsp[i].id == 12 || player2StackCardsp[i].id == 13)//CN
                p2has3 = true;
           
            if (player2StackCardsp[i].id == 14 || player2StackCardsp[i].id == 15 || player2StackCardsp[i].id == 16 || player2StackCardsp[i].id == 17)//IT
                p2has4 = true;
            
            if (player2StackCardsp[i].id == 18 || player2StackCardsp[i].id == 19 || player2StackCardsp[i].id == 20 || player2StackCardsp[i].id == 21 || player2StackCardsp[i].id == 22)//PM
                p2has5 = true;
        }

        for (int i = 0; i < player3StackCardsp.Count; i++)
        {
            if (player3StackCardsp[i].id == 0 || player3StackCardsp[i].id == 1 || player3StackCardsp[i].id == 2 || player3StackCardsp[i].id == 3 || player3StackCardsp[i].id == 4)//CR
                p3has1 = true;
            
            if (player3StackCardsp[i].id == 5 || player3StackCardsp[i].id == 6 || player3StackCardsp[i].id == 7 || player3StackCardsp[i].id == 8)//VC
                p3has2 = true;
            
            if (player3StackCardsp[i].id == 9 || player3StackCardsp[i].id == 10 || player3StackCardsp[i].id == 11 || player3StackCardsp[i].id == 12 || player3StackCardsp[i].id == 13)//CN
                p3has3 = true;
           
            if (player3StackCardsp[i].id == 14 || player3StackCardsp[i].id == 15 || player3StackCardsp[i].id == 16 || player3StackCardsp[i].id == 17)//IT
                p3has4 = true;
            
            if (player3StackCardsp[i].id == 18 || player3StackCardsp[i].id == 19 || player3StackCardsp[i].id == 20 || player3StackCardsp[i].id == 21 || player3StackCardsp[i].id == 22)//PM
                p3has5 = true;
        }

        for (int i = 0; i < player4StackCardsp.Count; i++)
        {
            if (player4StackCardsp[i].id == 0 || player4StackCardsp[i].id == 1 || player4StackCardsp[i].id == 2 || player4StackCardsp[i].id == 3 || player4StackCardsp[i].id == 4)//CR
                p4has1 = true;
            
            if (player4StackCardsp[i].id == 5 || player4StackCardsp[i].id == 6 || player4StackCardsp[i].id == 7 || player4StackCardsp[i].id == 8)//VC
                p4has2 = true;
            
            if (player4StackCardsp[i].id == 9 || player4StackCardsp[i].id == 10 || player4StackCardsp[i].id == 11 || player4StackCardsp[i].id == 12 || player4StackCardsp[i].id == 13)//CN
                p4has3 = true;
           
            if (player4StackCardsp[i].id == 14 || player4StackCardsp[i].id == 15 || player4StackCardsp[i].id == 16 || player4StackCardsp[i].id == 17)//IT
                p4has4 = true;
            
            if (player4StackCardsp[i].id == 18 || player4StackCardsp[i].id == 19 || player4StackCardsp[i].id == 20 || player4StackCardsp[i].id == 21 || player4StackCardsp[i].id == 22)//PM
                p4has5 = true;
        }

        if (p1has1 && p1has2 && p1has3 && p1has4 && p1has5 && !hasCompleteStackP1)
        {
            p1score += 5;
            player1Score.text = p1score + "";
            hasCompleteStackP1 = true;
        }
       
        if (p2has1 && p2has2 && p2has3 && p2has4 && p2has5 && !hasCompleteStackP2)
        {
            p2score += 5;
            player2Score.text = p2score + "";
            hasCompleteStackP2 = true;
        }
       
        if (p3has1 && p3has2 && p3has3 && p3has4 && p3has5 &&!hasCompleteStackP3)
        {
            p3score += 5;
            player3Score.text = p3score + "";
            hasCompleteStackP3 = true;
        }
        
        if (p4has1 && p4has2 && p4has3 && p4has4 && p4has5 && !hasCompleteStackP4)
        {
            p4score += 5;
            player4Score.text = p4score + "";
            hasCompleteStackP4 = true;
        }
        
        if(((TurnSystem.isPlayer1Turn && hasCompleteStackP1) || (TurnSystem.isPlayer2Turn && hasCompleteStackP2)
            || (TurnSystem.isPlayer3Turn && hasCompleteStackP3) || (TurnSystem.isPlayer4Turn && hasCompleteStackP4)) && !hasDrewCard)
        {
            DrawEventButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            DrawEventButton.GetComponent<Button>().interactable = false;
        }

        if(eventCard != null && (eventCard.GetComponent<ThisCard>().id == 23 || eventCard.GetComponent<ThisCard>().id == 24 || eventCard.GetComponent<ThisCard>().id == 25 || eventCard.GetComponent<ThisCard>().id == 26 || eventCard.GetComponent<ThisCard>().id == 27))
        {
            PerformEventButton.GetComponent<Button>().interactable = true;
        }
        else if(eventCard != null && eventCard.GetComponent<ThisCard>().id == 28) //CR tier 1
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for(int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if((player1StackCardsp[i].id == 0 || player1StackCardsp[i].id == 1 || player1StackCardsp[i].id == 2 || player1StackCardsp[i].id == 3 || player1StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 0 || player2StackCardsp[i].id == 1 || player2StackCardsp[i].id == 2 || player2StackCardsp[i].id == 3 || player2StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 0 || player3StackCardsp[i].id == 1 || player3StackCardsp[i].id == 2 || player3StackCardsp[i].id == 3 || player3StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 0 || player4StackCardsp[i].id == 1 || player4StackCardsp[i].id == 2 || player4StackCardsp[i].id == 3 || player4StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 29) //CN tier 1
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 9 || player1StackCardsp[i].id == 10 || player1StackCardsp[i].id == 11 || player1StackCardsp[i].id == 12 || player1StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 9 || player2StackCardsp[i].id == 10 || player2StackCardsp[i].id == 11 || player2StackCardsp[i].id == 12 || player2StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 9 || player3StackCardsp[i].id == 10 || player3StackCardsp[i].id == 11 || player3StackCardsp[i].id == 12 || player3StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 9 || player4StackCardsp[i].id == 10 || player4StackCardsp[i].id == 11 || player4StackCardsp[i].id == 12 || player4StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 30) //VC tier 1
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 5 || player1StackCardsp[i].id == 6 || player1StackCardsp[i].id == 7 || player1StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 5 || player2StackCardsp[i].id == 6 || player2StackCardsp[i].id == 7 || player2StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 5 || player3StackCardsp[i].id == 6 || player3StackCardsp[i].id == 7 || player3StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 5 || player4StackCardsp[i].id == 6 || player4StackCardsp[i].id == 7 || player4StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 31) //IT tier 1
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 14 || player1StackCardsp[i].id == 15 || player1StackCardsp[i].id == 16 || player1StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 14 || player2StackCardsp[i].id == 15 || player2StackCardsp[i].id == 16 || player2StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 14 || player3StackCardsp[i].id == 15 || player3StackCardsp[i].id == 16 || player3StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 14 || player4StackCardsp[i].id == 15 || player4StackCardsp[i].id == 16 || player4StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 32) //PM tier 1
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 18 || player1StackCardsp[i].id == 19 || player1StackCardsp[i].id == 20 || player1StackCardsp[i].id == 21 || player1StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if((player2StackCardsp[i].id == 18 || player2StackCardsp[i].id == 19 || player2StackCardsp[i].id == 20 || player2StackCardsp[i].id == 21 || player2StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 18 || player3StackCardsp[i].id == 19 || player3StackCardsp[i].id == 20 || player3StackCardsp[i].id == 21 || player3StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 18 || player4StackCardsp[i].id == 19 || player4StackCardsp[i].id == 20 || player4StackCardsp[i].id == 21 || player4StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 1)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }//--------------------------------------------------------------------------------------------------------------
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 33) //CR tier 2
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 0 || player1StackCardsp[i].id == 1 || player1StackCardsp[i].id == 2 || player1StackCardsp[i].id == 3 || player1StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 0 || player2StackCardsp[i].id == 1 || player2StackCardsp[i].id == 2 || player2StackCardsp[i].id == 3 || player2StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 0 || player3StackCardsp[i].id == 1 || player3StackCardsp[i].id == 2 || player3StackCardsp[i].id == 3 || player3StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 0 || player4StackCardsp[i].id == 1 || player4StackCardsp[i].id == 2 || player4StackCardsp[i].id == 3 || player4StackCardsp[i].id == 4) && CR.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 35) //CN tier 2
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 9 || player1StackCardsp[i].id == 10 || player1StackCardsp[i].id == 11 || player1StackCardsp[i].id == 12 || player1StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 9 || player2StackCardsp[i].id == 10 || player2StackCardsp[i].id == 11 || player2StackCardsp[i].id == 12 || player2StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 9 || player3StackCardsp[i].id == 10 || player3StackCardsp[i].id == 11 || player3StackCardsp[i].id == 12 || player3StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 9 || player4StackCardsp[i].id == 10 || player4StackCardsp[i].id == 11 || player4StackCardsp[i].id == 12 || player4StackCardsp[i].id == 13) && CN.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 37) //VC tier 2
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 5 || player1StackCardsp[i].id == 6 || player1StackCardsp[i].id == 7 || player1StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 5 || player2StackCardsp[i].id == 6 || player2StackCardsp[i].id == 7 || player2StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 5 || player3StackCardsp[i].id == 6 || player3StackCardsp[i].id == 7 || player3StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 5 || player4StackCardsp[i].id == 6 || player4StackCardsp[i].id == 7 || player4StackCardsp[i].id == 8) && VC.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 34) //IT tier 2
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 14 || player1StackCardsp[i].id == 15 || player1StackCardsp[i].id == 16 || player1StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 14 || player2StackCardsp[i].id == 15 || player2StackCardsp[i].id == 16 || player2StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 14 || player3StackCardsp[i].id == 15 || player3StackCardsp[i].id == 16 || player3StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 14 || player4StackCardsp[i].id == 15 || player4StackCardsp[i].id == 16 || player4StackCardsp[i].id == 17) && IT.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
        else if (eventCard != null && eventCard.GetComponent<ThisCard>().id == 36) //PM tier 2
        {
            if (TurnSystem.isPlayer1Turn)
            {
                for (int i = 0; i < player1StackCardsp.Count; i++)
                {
                    if ((player1StackCardsp[i].id == 18 || player1StackCardsp[i].id == 19 || player1StackCardsp[i].id == 20 || player1StackCardsp[i].id == 21 || player1StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                for (int i = 0; i < player2StackCardsp.Count; i++)
                {
                    if ((player2StackCardsp[i].id == 18 || player2StackCardsp[i].id == 19 || player2StackCardsp[i].id == 20 || player2StackCardsp[i].id == 21 || player2StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                for (int i = 0; i < player3StackCardsp.Count; i++)
                {
                    if ((player3StackCardsp[i].id == 18 || player3StackCardsp[i].id == 19 || player3StackCardsp[i].id == 20 || player3StackCardsp[i].id == 21 || player3StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                for (int i = 0; i < player4StackCardsp.Count; i++)
                {
                    if ((player4StackCardsp[i].id == 18 || player4StackCardsp[i].id == 19 || player4StackCardsp[i].id == 20 || player4StackCardsp[i].id == 21 || player4StackCardsp[i].id == 22) && PM.transform.GetChild(0).GetComponent<ThisCard>().tier == 2)
                    {
                        PerformEventButton.GetComponent<Button>().interactable = true;
                        break;
                    }
                }
            }
        }
              
        if(player1StackCardsp.Count < 5)
        {
            p1score = 0;
            hasCompleteStackP1 = false;
            p1has1 = false;
            p1has2 = false;
            p1has3 = false;
            p1has4 = false;
            p1has5 = false;
        }
        
        if (player2StackCardsp.Count < 5)
        {
            p2score = 0;
            hasCompleteStackP2 = false;
            p2has1 = false;
            p2has2 = false;
            p2has3 = false;
            p2has4 = false;
            p2has5 = false;
        }
        
        if (player3StackCardsp.Count < 5)
        {
            p3score = 0;
            hasCompleteStackP3 = false;
            p3has1 = false;
            p3has2 = false;
            p3has3 = false;
            p3has4 = false;
            p3has5 = false;
        }
        
        if (player4StackCardsp.Count < 5)
        {
            p4score = 0;
            hasCompleteStackP4 = false;
            p4has1 = false;
            p4has2 = false;
            p4has3 = false;
            p4has4 = false;
            p4has5 = false;
        }

        player1Score.text = p1score + "";
        player2Score.text = p2score + "";
        player3Score.text = p3score + "";
        player4Score.text = p4score + "";
    }

    IEnumerator Player1Cards(int x = 1, string type = "Tool")
    {
        drawType = type;

        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (drawType == "Upgrade")
            {
                GameObject c1 = Instantiate(CardToHand, transform.position, transform.rotation, Hand.transform);
                c1.name = "Player 1 Event Card " + cardNo;
                c1.GetComponent<ThisCard>().cardIndex = cardNo;
                c1.GetComponent<ThisCard>().cardType = "Event";
                cardNo++;
            }
            else
            {
                GameObject c1 = (GameObject)Instantiate(CardToHand, transform.position, transform.rotation, Hand.transform);
                
                if (drawType == "Event")
                {
                    eventCard = c1;
                    eventCard.name = "Player 1 Event Card " + cardNo;
                    eventCard.GetComponent<ThisCard>().cardIndex = cardNo;
                    eventCard.GetComponent<ThisCard>().cardType = "Event";
                }
                else
                {
                    c1.name = "Player 1 Normal Card " + cardNo;
                    c1.GetComponent<ThisCard>().cardIndex = cardNo;
                    c1.GetComponent<ThisCard>().cardType = "Normal";
                }
                cardNo++;
            }
        }
    }

    IEnumerator Player4Cards(int z = 1, string type = "Tool")
    {
        drawType = type;

        for (int i = 0; i < z; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject c1;
            if (drawType == "Upgrade")
            {
                c1 = Instantiate(CardToHand, transform.position, transform.rotation, Hand4.transform);
                c1.name = "Player 4 Event Card " + cardNo;
                c1.GetComponent<ThisCard>().cardIndex = cardNo;
                c1.GetComponent<ThisCard>().cardType = "Event";
               // eventCard = null;
                cardNo++;
            }
            else
            {
                c1 = (GameObject)Instantiate(CardToHand, transform.position, transform.rotation, Hand4.transform);

                if (drawType == "Event")
                {
                    eventCard = c1;
                    eventCard.name = "Player 4 Event Card " + cardNo;
                    eventCard.GetComponent<ThisCard>().cardIndex = cardNo;
                    eventCard.GetComponent<ThisCard>().cardType = "Event";
                }
                else
                {
                    c1.name = "Player 4 Normal Card " + cardNo;
                    c1.GetComponent<ThisCard>().cardIndex = cardNo;
                    c1.GetComponent<ThisCard>().cardType = "Normal";
                }
                cardNo++;
            }
            c1.transform.Rotate(0, 0, -90);
        }
    }

    IEnumerator Player2Cards(int z = 1, string type = "Tool")
    {
        drawType = type;

        for (int i = 0; i < z; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject c1;
            if (drawType == "Upgrade")
            {
                c1 = Instantiate(CardToHand, transform.position, transform.rotation, Hand2.transform);
                c1.name = "Player 2 Event Card " + cardNo;
                c1.GetComponent<ThisCard>().cardIndex = cardNo;
                c1.GetComponent<ThisCard>().cardType = "Event";
                //eventCard = null;
                cardNo++;
            }
            else
            {
                c1 = (GameObject)Instantiate(CardToHand, transform.position, transform.rotation, Hand2.transform);
                                
                if (drawType == "Event")
                {
                    eventCard = c1;
                    eventCard.name = "Player 2 Event Card " + cardNo;
                    eventCard.GetComponent<ThisCard>().cardIndex = cardNo;
                    eventCard.GetComponent<ThisCard>().cardType = "Event";
                }
                else
                {
                    c1.name = "Player 2 Normal Card " + cardNo;
                    c1.GetComponent<ThisCard>().cardIndex = cardNo;
                    c1.GetComponent<ThisCard>().cardType = "Normal";
                }
                cardNo++;
            }
            c1.transform.Rotate(0, 0, 90);
        }
    }

    IEnumerator Player3Cards(int z = 1, string type = "Tool")
    {
        drawType = type;

        for (int i = 0; i < z; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject c1;
            if (drawType == "Upgrade")
            {
                c1 = Instantiate(CardToHand, transform.position, transform.rotation, Hand3.transform);
                c1.name = "Player 3 Event Card " + cardNo;
                c1.GetComponent<ThisCard>().cardIndex = cardNo;
                c1.GetComponent<ThisCard>().cardType = "Event";
                eventCard = null;
                cardNo++;
            }
            else
            {
                c1 = (GameObject)Instantiate(CardToHand, transform.position, transform.rotation, Hand3.transform);
                                
                if (drawType == "Event")
                {
                    eventCard = c1;
                    eventCard.name = "Player 3 Event Card " + cardNo;
                    eventCard.GetComponent<ThisCard>().cardIndex = cardNo;
                    eventCard.GetComponent<ThisCard>().cardType = "Event";
                }
                else
                {
                    c1.name = "Player 3 Normal Card " + cardNo;
                    c1.GetComponent<ThisCard>().cardIndex = cardNo;
                    c1.GetComponent<ThisCard>().cardType = "Normal";
                }
                cardNo++;
            }
            c1.transform.Rotate(0, 0, 180);
        }
    }

    public void StartG()
    {
        GetComponent<PhotonView>().RPC("RpcStartG", RpcTarget.All);
    }

    [PunRPC]
    public void RpcStartG()
    {
        dealCardCallCount++;
        Debug.Log(dealCardCallCount);
        if (dealCardCallCount == 4)
        {
            hasDealtCards = true;
            //endTurnButton.GetComponent<Button>().interactable = true;
            DealCards.SetActive(false);
            //DrawButton.GetComponent<Button>().interactable = true;
        }

        if (TurnSystem.isPlayer1Turn)
        {
            StartCoroutine(Player1Cards(5, "Tool"));
            TurnSystem.isPlayer1Turn = false;
            TurnSystem.isPlayer2Turn = true;
            return;
        }
        else if(TurnSystem.isPlayer2Turn)
        {
            StartCoroutine(Player2Cards(5, "Tool"));
            TurnSystem.isPlayer2Turn = false;
            TurnSystem.isPlayer3Turn = true;
            return;
        }
        else if(TurnSystem.isPlayer3Turn)
        {
            StartCoroutine(Player3Cards(5, "Tool"));
            TurnSystem.isPlayer3Turn = false;
            TurnSystem.isPlayer4Turn = true;
            return;
        }
        else if(TurnSystem.isPlayer4Turn)
        {
            StartCoroutine(Player4Cards(5, "Tool"));
            TurnSystem.isPlayer4Turn = false;
            TurnSystem.isPlayer1Turn = true;
            return;
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < 23; i++)
        {
            container[0] = CardDatabase.cardsList[i];
            int randomIndex = Random.Range(i, 23);
            CardDatabase.cardsList[i] = CardDatabase.cardsList[randomIndex];
            CardDatabase.cardsList[randomIndex] = container[0];
        }
        for(int i = 23; i < 39; i++)
        {
            container[0] = CardDatabase.cardsList[i];
            int randomIndex = Random.Range(i, 39);
            CardDatabase.cardsList[i] = CardDatabase.cardsList[randomIndex];
            CardDatabase.cardsList[randomIndex] = container[0];
        }
    }

    public void DrawCard()
    {
        GetComponent<PhotonView>().RPC("RpcDrawCard", RpcTarget.All);
    }

    [PunRPC]
    public void RpcDrawCard()
    {
        if (TurnSystem.isPlayer1Turn && !hasDrewCard)
        {
            StartCoroutine(Player1Cards());
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = false;
        }
        if (TurnSystem.isPlayer2Turn && !hasDrewCard)
        {
            StartCoroutine(Player2Cards());
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = false;
        }
        if (TurnSystem.isPlayer3Turn && !hasDrewCard)
        {
            StartCoroutine(Player3Cards());
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = false;
        } 
        if (TurnSystem.isPlayer4Turn && !hasDrewCard)
        {
            StartCoroutine(Player4Cards());
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
            endTurnButton.GetComponent<Button>().interactable = false;
        }


    }

    public void DrawEventCard()
    {
        GetComponent<PhotonView>().RPC("RpcDrawEventCard", RpcTarget.All);
    }

    [PunRPC]
    public void RpcDrawEventCard()
    {
        if (TurnSystem.isPlayer1Turn && !hasDrewCard)
        {
            StartCoroutine(Player1Cards(1,"Event"));
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
        }
        if (TurnSystem.isPlayer2Turn && !hasDrewCard)
        {
            StartCoroutine(Player2Cards(1, "Event"));
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
        }
        if (TurnSystem.isPlayer3Turn && !hasDrewCard)
        {
            StartCoroutine(Player3Cards(1, "Event"));
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
        }
        if (TurnSystem.isPlayer4Turn && !hasDrewCard)
        {
            StartCoroutine(Player4Cards(1, "Event"));
            hasDrewCard = true;
            DrawButton.GetComponent<Button>().interactable = false;
            DrawEventButton.GetComponent<Button>().interactable = false;
        }
    }

    public void PerformEvent()
    {
        GetComponent<PhotonView>().RPC("RpcPerformEvent", RpcTarget.All);
    }

    [PunRPC]
    public void RpcPerformEvent()
    {
        if (eventCard != null)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                Debug.Log("Upgrade");

                if(eventCard.GetComponent<ThisCard>().id == 33 || eventCard.GetComponent<ThisCard>().id == 34 || eventCard.GetComponent<ThisCard>().id == 35 || eventCard.GetComponent<ThisCard>().id == 36 || eventCard.GetComponent<ThisCard>().id == 37)
                {
                    StartCoroutine(Player1Cards(2, "Upgrade"));
                }
                else
                {
                    StartCoroutine(Player1Cards(1, "Upgrade"));
                }
            }
            if (TurnSystem.isPlayer2Turn)
            {
                Debug.Log("Upgrade");

                if (eventCard.GetComponent<ThisCard>().id == 33 || eventCard.GetComponent<ThisCard>().id == 34 || eventCard.GetComponent<ThisCard>().id == 35 || eventCard.GetComponent<ThisCard>().id == 36 || eventCard.GetComponent<ThisCard>().id == 37)
                {
                    StartCoroutine(Player2Cards(2, "Upgrade"));
                }
                else
                {
                    StartCoroutine(Player2Cards(1, "Upgrade"));
                }
            }
            if (TurnSystem.isPlayer3Turn)
            {
                Debug.Log("Upgrade");

                if (eventCard.GetComponent<ThisCard>().id == 33 || eventCard.GetComponent<ThisCard>().id == 34 || eventCard.GetComponent<ThisCard>().id == 35 || eventCard.GetComponent<ThisCard>().id == 36 || eventCard.GetComponent<ThisCard>().id == 37)
                {
                    StartCoroutine(Player3Cards(2, "Upgrade"));
                }
                else
                {
                    StartCoroutine(Player3Cards(1, "Upgrade"));
                }
            }
            if (TurnSystem.isPlayer4Turn)
            {
                Debug.Log("Upgrade");

                if (eventCard.GetComponent<ThisCard>().id == 33 || eventCard.GetComponent<ThisCard>().id == 34 || eventCard.GetComponent<ThisCard>().id == 35 || eventCard.GetComponent<ThisCard>().id == 36 || eventCard.GetComponent<ThisCard>().id == 37)
                {
                    StartCoroutine(Player4Cards(2, "Upgrade"));
                }
                else
                {
                    StartCoroutine(Player4Cards(1, "Upgrade"));
                }
            }
            Destroy(eventCard);
            eventCard = null;
        }
    }
}
