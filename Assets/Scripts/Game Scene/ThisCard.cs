using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public string owner;
    public int tier;
    public int cardIndex;
    public string cardDescription;

    public Sprite thisSprite;
    public Image logo;

    public GameObject Hand;
    public GameObject Hand2;
    public GameObject Hand3;
    public GameObject Hand4;

    public GameObject CardViewer;

    public GameObject Discarded1;
    public GameObject Discarded2;
    public GameObject Discarded3;
    public GameObject Discarded4;

    public static int numberOfCardsInDeck;
    public static int numberOfCardsInEventDeck;
    public static int numberOfCardsInUpgradeDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject stackZone;
    public GameObject stackZone2;
    public GameObject stackZone3;
    public GameObject stackZone4;
    public GameObject stackZone5;

    [HideInInspector]
    public string cardType;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        numberOfCardsInEventDeck = PlayerDeck.eventDeckSize;
        numberOfCardsInUpgradeDeck = PlayerDeck.upgradeDeckSize;
        canBeSummon = false;
        summoned = false;
        Hand = GameObject.Find("Hand");
        Hand2 = GameObject.Find("Hand2");
        Hand3 = GameObject.Find("Hand3");
        Hand4 = GameObject.Find("Hand4");
        stackZone = GameObject.Find("PM1");
        stackZone2 = GameObject.Find("CR1");
        stackZone3 = GameObject.Find("CN1");
        stackZone4 = GameObject.Find("IT1");
        stackZone5 = GameObject.Find("VC1");
        CardViewer = GameObject.Find("CardViewer");
        Discarded1 = GameObject.Find("Discarded Player 1");
        Discarded2 = GameObject.Find("Discarded Player 2");
        Discarded3 = GameObject.Find("Discarded Player 3");
        Discarded4 = GameObject.Find("Discarded Player 4");
    }

    // Update is called once per frame
    void Update()
    {
        //Tool Card Instantiation
        if (this.tag == "Clone" && PlayerDeck.drawType == "Tool")
        {
            thisCard[0] = PlayerDeck.staticDeck[PlayerDeck.staticDeck.Count - 1];
            thisSprite = thisCard[0].logo;
            id = thisCard[0].id;
            tier = thisCard[0].tier;
            cardName = thisCard[0].cardName;
            cardIndex = thisCard[0].cardNo;
            if (TurnSystem.isPlayer1Turn)
            {
                gameObject.name = "Player 1 Normal Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                gameObject.name = "Player 2 Normal Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                gameObject.name = "Player 3 Normal Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                gameObject.name = "Player 4 Normal Card " + cardIndex;
            }

            Debug.Log("Card Index is " + cardIndex);
            //logo.GetComponent<Image>().sprite = Resources.Load<Sprite>("CardBack");

            if (TurnSystem.isPlayer1Turn)
            {
                owner = "Hand";
                //PlayerDeck.player1Cards.Add(thisCard[0]);
            }

            if (TurnSystem.isPlayer2Turn)
            {
                owner = "Hand2";
               // PlayerDeck.player2Cards.Add(thisCard[0]);
            }

            if (TurnSystem.isPlayer3Turn)
            {
                owner = "Hand3";
               // PlayerDeck.player3Cards.Add(thisCard[0]);
            }

            if (TurnSystem.isPlayer4Turn)
            {
                owner = "Hand4";
                //PlayerDeck.player4Cards.Add(thisCard[0]);
            }

            PlayerDeck.staticDeck.RemoveAt(PlayerDeck.staticDeck.Count - 1);

            if (thisCard[0].id == 0 || thisCard[0].id == 1 || thisCard[0].id == 2 || thisCard[0].id == 3 || thisCard[0].id == 4)
            {
                this.tag = "CR";
            }
            else if (thisCard[0].id == 5 || thisCard[0].id == 6 || thisCard[0].id == 7 || thisCard[0].id == 8 || thisCard[0].id == 43)
            {
                this.tag = "VC";
            }
            else if (thisCard[0].id == 9 || thisCard[0].id == 10 || thisCard[0].id == 11 || thisCard[0].id == 12 || thisCard[0].id == 13)
            {
                this.tag = "CN";
            }
            else if (thisCard[0].id == 14 || thisCard[0].id == 15 || thisCard[0].id == 16 || thisCard[0].id == 17 || thisCard[0].id == 42)
            {
                this.tag = "IT";
            }
            else if (thisCard[0].id == 18 || thisCard[0].id == 19 || thisCard[0].id == 20 || thisCard[0].id == 21 || thisCard[0].id == 22)
            {
                this.tag = "PM";
            }
            else
            {
                this.tag = "Untagged";
            }
        }

        //Event, Upgrade Card Instantiation
        if (this.tag == "Clone" && PlayerDeck.drawType == "Event")
        {
            thisCard[0] = PlayerDeck.staticEventDeck[PlayerDeck.staticEventDeck.Count - 1];
            PlayerDeck.eventCardPlayed = PlayerDeck.staticEventDeck[PlayerDeck.staticEventDeck.Count - 1];
            thisSprite = thisCard[0].logo;
            id = thisCard[0].id;
            tier = thisCard[0].tier;
            cardIndex = thisCard[0].cardNo;
            //logo.GetComponent<Image>().sprite = Resources.Load<Sprite>("CardBack");
            if (TurnSystem.isPlayer1Turn)
            {
                gameObject.name = "Player 1 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                gameObject.name = "Player 2 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                gameObject.name = "Player 3 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                gameObject.name = "Player 4 Event Card " + cardIndex;
            }

            if (TurnSystem.isPlayer1Turn)
            {
                owner = "Hand";
            }

            if (TurnSystem.isPlayer2Turn)
            {
                owner = "Hand2";
            }

            if (TurnSystem.isPlayer3Turn)
            {
                owner = "Hand3";
            }

            if (TurnSystem.isPlayer4Turn)
            {
                owner = "Hand4";
            }

            PlayerDeck.staticEventDeck.RemoveAt(PlayerDeck.staticEventDeck.Count - 1);

            if (thisCard[0].id == 38)
            {
                this.tag = "Upgrade";
            }
            else
            {
                this.tag = "Event";
            }
        }

        //Upgrade Card Instantiation
        if (this.tag == "Clone" && PlayerDeck.drawType == "Upgrade")
        {
            thisCard[0] = PlayerDeck.staticUpgradeDeck[PlayerDeck.staticUpgradeDeck.Count - 1];
            thisSprite = thisCard[0].logo;
            id = thisCard[0].id;
            tier = thisCard[0].tier;
            cardIndex = thisCard[0].cardNo;
            if (TurnSystem.isPlayer1Turn)
            {
                gameObject.name = "Player 1 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer2Turn)
            {
                gameObject.name = "Player 2 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer3Turn)
            {
                gameObject.name = "Player 3 Event Card " + cardIndex;
            }
            else if (TurnSystem.isPlayer4Turn)
            {
                gameObject.name = "Player 4 Event Card " + cardIndex;
            }
            //logo.GetComponent<Image>().sprite = Resources.Load<Sprite>("CardBack");

            if (TurnSystem.isPlayer1Turn)
            {
                owner = "Hand";
            }

            if (TurnSystem.isPlayer2Turn)
            {
                owner = "Hand2";
            }

            if (TurnSystem.isPlayer3Turn)
            {
                owner = "Hand3";
            }

            if (TurnSystem.isPlayer4Turn)
            {
                owner = "Hand4";
            }

            PlayerDeck.staticUpgradeDeck.RemoveAt(PlayerDeck.staticUpgradeDeck.Count - 1);

            this.tag = "Upgrade";
        }

        //Assigning Values for Instantiated Cards
        if (owner == "Hand2" || owner == "Hand3" || owner == "Hand4")
        {
            logo.GetComponent<Image>().sprite = Resources.Load<Sprite>("CardBack");
        }
        else
        {
            logo.GetComponent<Image>().sprite = thisSprite;
        }
        

        //Conditions for a player to be allowed to drag a card
        if (summoned == false && TurnSystem.isPlayer1Turn && (owner == "Hand" || owner == "Discarded4" || owner == "CardViewer" 
            || owner == "PM1" || owner == "CN1" || owner == "CR1" || owner == "IT1" || owner == "VC1"))
        {
            canBeSummon = true;
        }
        else if (summoned == false && TurnSystem.isPlayer2Turn && (owner == "Hand2" || owner == "Discarded1" || owner == "CardViewer"
            || owner == "PM2"|| owner == "CN2" || owner == "CR2" || owner == "IT2" || owner == "VC2"))
        {
            canBeSummon = true;
        }
        else if (summoned == false && TurnSystem.isPlayer3Turn && (owner == "Hand3" || owner == "Discarded2" || owner == "CardViewer"
             || owner == "PM3" || owner == "CN3" || owner == "CR3" || owner == "IT3" || owner == "VC3"))
        {
            canBeSummon = true;
        }
        else if (summoned == false && TurnSystem.isPlayer4Turn && (owner == "Hand4" || owner == "Discarded3" || owner == "CardViewer"
             || owner == "PM4" || owner == "CN4" || owner == "CR4" || owner == "IT4" || owner == "VC4"))
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        //Check if condition, then player can drag the card
        if (canBeSummon)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }


        //StackZones are assigned according to player turn
        if (TurnSystem.isPlayer1Turn)
        {
            stackZone = GameObject.Find("PM1");
            stackZone2 = GameObject.Find("CR1");
            stackZone3 = GameObject.Find("CN1");
            stackZone4 = GameObject.Find("IT1");
            stackZone5 = GameObject.Find("VC1");

        }
        if (TurnSystem.isPlayer2Turn)
        {
            stackZone = GameObject.Find("PM2");
            stackZone2 = GameObject.Find("CR2");
            stackZone3 = GameObject.Find("CN2");
            stackZone4 = GameObject.Find("IT2");
            stackZone5 = GameObject.Find("VC2");
        }
        if (TurnSystem.isPlayer3Turn)
        {
            stackZone = GameObject.Find("PM3");
            stackZone2 = GameObject.Find("CR3");
            stackZone3 = GameObject.Find("CN3");
            stackZone4 = GameObject.Find("IT3");
            stackZone5 = GameObject.Find("VC3");
        }
        if (TurnSystem.isPlayer4Turn)
        {
            stackZone = GameObject.Find("PM4");
            stackZone2 = GameObject.Find("CR4");
            stackZone3 = GameObject.Find("CN4");
            stackZone4 = GameObject.Find("IT4");
            stackZone5 = GameObject.Find("VC4");
        }

        if (stackZone.transform.childCount == 0)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                GameObject.Find("PM1 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer2Turn)
            {
                GameObject.Find("PM2 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer3Turn)
            {
                GameObject.Find("PM3 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer4Turn)
            {
                GameObject.Find("PM4 Title").GetComponent<Text>().text = "";
            }
        }

        if (stackZone2.transform.childCount == 0)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                GameObject.Find("CR1 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer2Turn)
            {
                GameObject.Find("CR2 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer3Turn)
            {
                GameObject.Find("CR3 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer4Turn)
            {
                GameObject.Find("CR4 Title").GetComponent<Text>().text = "";
            }
        }

        if (stackZone3.transform.childCount == 0)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                GameObject.Find("CN1 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer2Turn)
            {
                GameObject.Find("CN2 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer3Turn)
            {
                GameObject.Find("CN3 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer4Turn)
            {
                GameObject.Find("CN4 Title").GetComponent<Text>().text = "";
            }
        }

        if (stackZone4.transform.childCount == 0)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                GameObject.Find("IT1 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer2Turn)
            {
                GameObject.Find("IT2 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer3Turn)
            {
                GameObject.Find("IT3 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer4Turn)
            {
                GameObject.Find("IT4 Title").GetComponent<Text>().text = "";
            }
        }

        if (stackZone5.transform.childCount == 0)
        {
            if (TurnSystem.isPlayer1Turn)
            {
                GameObject.Find("VC1 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer2Turn)
            {
                GameObject.Find("VC2 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer3Turn)
            {
                GameObject.Find("VC3 Title").GetComponent<Text>().text = "";
            }
            if (TurnSystem.isPlayer4Turn)
            {
                GameObject.Find("VC4 Title").GetComponent<Text>().text = "";
            }
        }

        //Conditions for adding and Removing Cards
        if (this.gameObject.transform.parent == Hand.transform && owner != "Hand")
        {
            this.transform.rotation = Hand.transform.rotation;
            if (this.tag == "PM Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "PM";
            }
            else if (this.tag == "CR Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CR";
            }
            else if (this.tag == "CN Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CN";
            }
            else if (this.tag == "VC Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "VC";
            }
            else if (this.tag == "IT Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "IT";
            }

            if (owner != "PM1" && owner != "CN1" && owner != "VC1" && owner != "IT1" && owner != "CR1")
            {
                PlayerDeck.player1Cards.Add(thisCard[0]);
            }
            else
            {
                PlayerDeck.player1StackCards.Remove(thisCard[0]);
            }
            owner = "Hand";
        }
        else if (this.gameObject.transform.parent == Hand2.transform && owner != "Hand2")
        {
            this.transform.rotation = Hand2.transform.rotation;
            if (this.tag == "PM Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "PM";
            }
            else if (this.tag == "CR Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CR";
            }
            else if (this.tag == "CN Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CN";
            }
            else if (this.tag == "VC Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "VC";
            }
            else if (this.tag == "IT Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "IT";
            }

            if (owner != "PM2" && owner != "CN2" && owner != "VC2" && owner != "IT2" && owner != "CR2")
            {
                PlayerDeck.player2Cards.Add(thisCard[0]);
            }
            else
            {
                PlayerDeck.player2StackCards.Remove(thisCard[0]);
            }
            owner = "Hand2";
        }
        else if (this.transform.parent == Hand3.transform && owner != "Hand3")
        {
            this.transform.rotation = Hand3.transform.rotation;
            if (this.tag == "PM Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "PM";
            }
            else if (this.tag == "CR Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CR";
            }
            else if (this.tag == "CN Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CN";
            }
            else if (this.tag == "VC Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "VC";
            }
            else if (this.tag == "IT Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "IT";
            }

            if (owner != "PM3" && owner != "CN3" && owner != "VC3" && owner != "IT3" && owner != "CR3")
            {
                PlayerDeck.player3Cards.Add(thisCard[0]);
            }
            else
            {
                PlayerDeck.player3StackCards.Remove(thisCard[0]);
            }
            owner = "Hand3";
        }
        else if (this.transform.parent == Hand4.transform && owner != "Hand4")
        {
            this.transform.rotation = Hand4.transform.rotation;
            if (this.tag == "PM Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "PM";
            }
            else if (this.tag == "CR Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CR";
            }
            else if (this.tag == "CN Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "CN";
            }
            else if (this.tag == "VC Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "VC";
            }
            else if (this.tag == "IT Discarded")
            {
                PlayerDeck.hasDrewCard = true;
                PlayerDeck.hasDiscardedCard2 = true;
                this.tag = "IT";
            }

            if (owner != "PM4" && owner != "CN4" && owner != "VC4" && owner != "IT4" && owner != "CR4")
            {
                PlayerDeck.player4Cards.Add(thisCard[0]);
            }
            else
            {
                PlayerDeck.player4StackCards.Remove(thisCard[0]);
            }
            owner = "Hand4";

        }
        else if(this.gameObject.transform.parent == Discarded1.transform && owner == "Hand")
        {
            owner = "Discarded1";
            if(this.tag == "PM")
            {
                this.tag = "PM Discarded";
            }
            else if(this.tag == "CR")
            {
                this.tag = "CR Discarded";
            }
            else if (this.tag == "CN")
            {
                this.tag = "CN Discarded";
            }
            else if (this.tag == "VC")
            {
                this.tag = "VC Discarded";
            }
            else if (this.tag == "IT")
            {
                this.tag = "IT Discarded";
            }
            this.transform.SetAsLastSibling();
            transform.rotation = Discarded1.transform.rotation;
            PlayerDeck.player1Cards.Remove(thisCard[0]);
        }
        else if (this.transform.parent == Discarded2.transform && owner == "Hand2")
        {
            this.transform.rotation = Discarded2.transform.rotation;
            this.transform.SetAsLastSibling();
            owner = "Discarded2";
            if (this.tag == "PM")
            {
                this.tag = "PM Discarded";
            }
            else if (this.tag == "CR")
            {
                this.tag = "CR Discarded";
            }
            else if (this.tag == "CN")
            {
                this.tag = "CN Discarded";
            }
            else if (this.tag == "VC")
            {
                this.tag = "VC Discarded";
            }
            else if (this.tag == "IT")
            {
                this.tag = "IT Discarded";
            }
            
            PlayerDeck.player2Cards.Remove(thisCard[0]);
        }
        else if (this.transform.parent == Discarded3.transform && owner == "Hand3")
        {
            this.transform.rotation = Discarded3.transform.rotation;
            this.transform.SetAsLastSibling();
            owner = "Discarded3";
            if (this.tag == "PM")
            {
                this.tag = "PM Discarded";
            }
            else if (this.tag == "CR")
            {
                this.tag = "CR Discarded";
            }
            else if (this.tag == "CN")
            {
                this.tag = "CN Discarded";
            }
            else if (this.tag == "VC")
            {
                this.tag = "VC Discarded";
            }
            else if (this.tag == "IT")
            {
                this.tag = "IT Discarded";
            }
            
            PlayerDeck.player3Cards.Remove(thisCard[0]);
        }
        else if (this.transform.parent == Discarded4.transform && owner == "Hand4")
        {
            this.transform.rotation = Discarded4.transform.rotation;
            this.transform.SetAsLastSibling();
            owner = "Discarded4";
            if (this.tag == "PM")
            {
                this.tag = "PM Discarded";
            }
            else if (this.tag == "CR")
            {
                this.tag = "CR Discarded";
            }
            else if (this.tag == "CN")
            {
                this.tag = "CN Discarded";
            }
            else if (this.tag == "VC")
            {
                this.tag = "VC Discarded";
            }
            else if (this.tag == "IT")
            {
                this.tag = "IT Discarded";
            }
            PlayerDeck.player4Cards.Remove(thisCard[0]);
        }

        if (summoned == false && this.transform.parent == stackZone.transform) {
            if (TurnSystem.isPlayer1Turn && (owner != "PM1" && owner != "Discarded4") && (this.tag == "PM" || this.tag == "Upgrade"))
            {
                if (stackZone.transform.childCount > 2 && this.tag == "PM")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand.transform);
                }
                else
                {
                    Debug.Log("Owner is " + owner);
                    owner = "PM1";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.pm1);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM1 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM1 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("PM1 Title").GetComponent<Text>().text = cardName + " " + tier;
                        GameObject.Find("PM1 Title2").GetComponent<Text>().text = "PM";
                        if (tier == 2)
                        {
                            PlayerDeck.p1score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p1score += 2;
                        }
                        PlayerDeck.pm1 = gameObject.name;
                        PlayerDeck.player1StackCards.Add(thisCard[0]);
                        PlayerDeck.player1Cards.Remove(thisCard[0]);
                    }
                }
            }

            if (TurnSystem.isPlayer1Turn && owner != "PM1" && this.tag != "PM" && this.tag != "Upgrade")
            {
                if (owner == "Discarded4")
                {
                    this.transform.SetParent(Discarded4.transform);
                }
                else
                {
                    this.transform.SetParent(Hand.transform);
                }
            }

            if (TurnSystem.isPlayer2Turn && (owner != "PM2" && owner != "Discarded1") && (this.tag == "PM" || this.tag == "Upgrade"))
            {
                if (stackZone.transform.childCount > 1 && this.tag == "PM")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand2.transform);
                }
                else
                {
                    owner = "PM2";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.pm2);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM2 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM2 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand2.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("PM2 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("PM2 Title2").GetComponent<Text>().text = "PM";
                        if (tier == 2)
                        {
                            PlayerDeck.p2score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p2score += 2;
                        }
                        PlayerDeck.player2StackCards.Add(thisCard[0]);
                        PlayerDeck.player2Cards.Remove(thisCard[0]);
                        PlayerDeck.pm2 = gameObject.name;
                    }
                }

            }

            if (TurnSystem.isPlayer2Turn && owner != "PM2" && this.tag != "PM" && this.tag != "Upgrade")
            {
                if (owner == "Discarded1")
                {
                    this.transform.SetParent(Discarded1.transform);
                }
                else
                {
                    this.transform.SetParent(Hand2.transform);
                }
            }

            if (TurnSystem.isPlayer3Turn && (owner != "PM3" && owner != "Discarded2") && (this.tag == "PM" || this.tag == "Upgrade"))
            {
                if (stackZone.transform.childCount > 1 && this.tag == "PM")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand3.transform);
                }
                else
                {
                    owner = "PM3";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.pm3);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM3 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM3 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand3.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("PM3 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("PM3 Title2").GetComponent<Text>().text = "PM";
                        if (tier == 2)
                        {
                            PlayerDeck.p3score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p3score += 2;
                        }
                        PlayerDeck.player3StackCards.Add(thisCard[0]);
                        PlayerDeck.player3Cards.Remove(thisCard[0]);
                        PlayerDeck.pm3 = gameObject.name;
                    }
                }

            }

            if (TurnSystem.isPlayer3Turn && owner != "PM3" && this.tag != "PM" && this.tag != "Upgrade")
            {
                if (owner == "Discarded2")
                {
                    this.transform.SetParent(Discarded2.transform);
                }
                else
                {
                    this.transform.SetParent(Hand3.transform);
                }
            }

            if (TurnSystem.isPlayer4Turn && (owner != "PM4" && owner != "Discarded3") && (this.tag == "PM" || this.tag == "Upgrade"))
            {
                if (stackZone.transform.childCount > 1 && this.tag == "PM")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand4.transform);
                }
                else
                {
                    owner = "PM4";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.pm4);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM4 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 18)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 19)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 20)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 21)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 PM");
                            }
                            else if (card.GetComponent<ThisCard>().id == 22)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 PM");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("PM4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("PM4 Title2").GetComponent<Text>().text = "PM";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand4.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("PM4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("PM4 Title2").GetComponent<Text>().text = "PM";
                        if (tier == 2)
                        {
                            PlayerDeck.p4score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p4score += 2;
                        }
                        PlayerDeck.player4StackCards.Add(thisCard[0]);
                        PlayerDeck.player4Cards.Remove(thisCard[0]);
                        PlayerDeck.pm4 = gameObject.name;
                    }
                }

            }

            if (TurnSystem.isPlayer4Turn && owner != "PM4" && this.tag != "PM" && this.tag != "Upgrade")
            {
                if (owner == "Discarded3")
                {
                    this.transform.SetParent(Discarded3.transform);
                }
                else
                {
                    this.transform.SetParent(Hand4.transform);
                }
            }
        }
        else if (summoned == false && this.transform.parent == stackZone2.transform)
        {
            if (TurnSystem.isPlayer1Turn && (owner != "CR1" && owner != "Discarded4") && (this.tag == "CR" || this.tag == "Upgrade"))
            {
                if (stackZone2.transform.childCount > 2 && this.tag == "CR")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand.transform);
                }
                else
                {

                    owner = "CR1";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cr1);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR1 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CR");
                            }
                            else if (stackZone.transform.GetChild(1).GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR1 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("CR1 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CR1 Title2").GetComponent<Text>().text = "CR";
                        if (tier == 2)
                        {
                            PlayerDeck.p1score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p1score += 2;
                        }
                        PlayerDeck.player1StackCards.Add(thisCard[0]);
                        PlayerDeck.player1Cards.Remove(thisCard[0]);
                        PlayerDeck.cr1 = gameObject.name; 
                    }
                }

            }

            if (TurnSystem.isPlayer1Turn && owner != "CR1" && this.tag != "CR" && this.tag != "Upgrade")
            {
                if (owner == "Discarded4")
                {
                    this.transform.SetParent(Discarded4.transform);
                }
                else
                {
                    this.transform.SetParent(Hand.transform);
                }
            }

            if (TurnSystem.isPlayer2Turn && (owner != "CR2" && owner != "Discarded1") && (this.tag == "CR" || this.tag == "Upgrade"))
            {
                if (stackZone2.transform.childCount > 1 && this.tag == "CR")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand2.transform);
                }
                else
                {

                    owner = "CR2";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cr2);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR2 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR2 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand2.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("CR2 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CR2 Title2").GetComponent<Text>().text = "CR";
                        if (tier == 2)
                        {
                            PlayerDeck.p2score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p2score += 2;
                        }
                        PlayerDeck.player2StackCards.Add(thisCard[0]);
                        PlayerDeck.player2Cards.Remove(thisCard[0]);
                        PlayerDeck.cr2 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer2Turn && owner != "CR2" && this.tag != "CR" && this.tag != "Upgrade")
            {
                if (owner == "Discarded1")
                {
                    this.transform.SetParent(Discarded1.transform);
                }
                else
                {
                    this.transform.SetParent(Hand2.transform);
                }
            }

            if (TurnSystem.isPlayer3Turn && (owner != "CR3" && owner != "Discarded2") && (this.tag == "CR" || this.tag == "Upgrade"))
            {
                if (stackZone2.transform.childCount > 1 && this.tag == "CR")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand3.transform);
                }
                else
                {

                    owner = "CR3";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cr3);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR3 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR3 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand3.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("CR3 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CR3 Title2").GetComponent<Text>().text = "CR";
                        if (tier == 2)
                        {
                            PlayerDeck.p3score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p3score += 2;
                        }
                        PlayerDeck.player3StackCards.Add(thisCard[0]);
                        PlayerDeck.player3Cards.Remove(thisCard[0]);
                        PlayerDeck.cr3 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer3Turn && owner != "CR3" && this.tag != "CR" && this.tag != "Upgrade")
            {
                if (owner == "Discarded2")
                {
                    this.transform.SetParent(Discarded2.transform);
                }
                else
                {
                    this.transform.SetParent(Hand3.transform);
                }
            }

            if (TurnSystem.isPlayer4Turn && (owner != "CR4" && owner != "Discarded3") && (this.tag == "CR" || this.tag == "Upgrade"))
            {
                if (stackZone2.transform.childCount > 1 && this.tag == "CR")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand4.transform);
                }
                else
                {
                    owner = "CR4";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cr4);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR4 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 0)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 1)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 2)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 3)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CR");
                            }
                            else if (card.GetComponent<ThisCard>().id == 4)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CR");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CR4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CR4 Title2").GetComponent<Text>().text = "CR";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand4.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("CR4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CR4 Title2").GetComponent<Text>().text = "CR";
                        if (tier == 2)
                        {
                            PlayerDeck.p4score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p4score += 2;
                        }
                        PlayerDeck.player4StackCards.Add(thisCard[0]);
                        PlayerDeck.player4Cards.Remove(thisCard[0]);
                        PlayerDeck.cr4 = gameObject.name;
                    }
                }

            }

            if (TurnSystem.isPlayer4Turn && owner != "CR4" && this.tag != "CR" && this.tag != "Upgrade")
            {
                if (owner == "Discarded3")
                {
                    this.transform.SetParent(Discarded3.transform);
                }
                else
                {
                    this.transform.SetParent(Hand4.transform);
                }
            }
        }
        else if (summoned == false && this.transform.parent == stackZone3.transform)
        {
            if (TurnSystem.isPlayer1Turn && (owner != "CN1" && owner != "Discarded4") && (this.tag == "CN" || this.tag == "Upgrade"))
            {
                if (stackZone3.transform.childCount > 2 && this.tag == "CN")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand.transform);
                }
                else
                {
                    owner = "CN1";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cn1);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN1 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN1 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("CN1 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CN1 Title2").GetComponent<Text>().text = "CI";
                        if (tier == 2)
                        {
                            PlayerDeck.p1score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p1score += 2;
                        }
                        PlayerDeck.player1StackCards.Add(thisCard[0]);
                        PlayerDeck.player1Cards.Remove(thisCard[0]);
                        PlayerDeck.cn1 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer1Turn && owner != "CN1" && this.tag != "CN" && this.tag != "Upgrade")
            {
                if (owner == "Discarded4")
                {
                    this.transform.SetParent(Discarded4.transform);
                }
                else
                {
                    this.transform.SetParent(Hand.transform);
                }
            }

            if (TurnSystem.isPlayer2Turn && (owner != "CN2" && owner != "Discarded1") && (this.tag == "CN" || this.tag == "Upgrade"))
            {
                if (stackZone3.transform.childCount > 1 && this.tag == "CN")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand2.transform);
                }
                else
                {
                    owner = "CN2";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cn2);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN2 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN2 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand2.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("CN2 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CN2 Title2").GetComponent<Text>().text = "CI";
                        if (tier == 2)
                        {
                            PlayerDeck.p2score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p2score += 2;
                        }
                        PlayerDeck.player2StackCards.Add(thisCard[0]);
                        PlayerDeck.player2Cards.Remove(thisCard[0]);
                        PlayerDeck.cn2 = gameObject.name;
                    }
                }
            }
            if (TurnSystem.isPlayer2Turn && owner != "CN2" && this.tag != "CN" && this.tag != "Upgrade")
            {
                if (owner == "Discarded1")
                {
                    this.transform.SetParent(Discarded1.transform);
                }
                else
                {
                    this.transform.SetParent(Hand2.transform);
                }
            }

            if (TurnSystem.isPlayer3Turn && (owner != "CN3" && owner != "Discarded2") && (this.tag == "CN" || this.tag == "Upgrade"))
            {
                if (stackZone3.transform.childCount > 1 && this.tag == "CN")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand3.transform);
                }
                else
                {
                    owner = "CN3";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cn3);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN3 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN3 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand3.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("CN3 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CN3 Title2").GetComponent<Text>().text = "CI";
                        if (tier == 2)
                        {
                            PlayerDeck.p3score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p3score += 2;
                        }
                        PlayerDeck.player3StackCards.Add(thisCard[0]);
                        PlayerDeck.player3Cards.Remove(thisCard[0]);
                        PlayerDeck.cn3 = gameObject.name;
                    }
                }
            }
            if (TurnSystem.isPlayer3Turn && owner != "CN3" && this.tag != "CN" && this.tag != "Upgrade")
            {
                if (owner == "Discarded2")
                {
                    this.transform.SetParent(Discarded2.transform);
                }
                else
                {
                    this.transform.SetParent(Hand3.transform);
                }
            }

            if (TurnSystem.isPlayer4Turn && (owner != "CN4" && owner != "Discarded3") && (this.tag == "CN" || this.tag == "Upgrade"))
            {
                if (stackZone3.transform.childCount > 1 && this.tag == "CN")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand4.transform);
                }
                else
                {
                    owner = "CN4";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.cn4);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN4 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 9)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 10)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 11)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 12)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 CN");
                            }
                            else if (card.GetComponent<ThisCard>().id == 13)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 CN");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("CN4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("CN4 Title2").GetComponent<Text>().text = "CI";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand4.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("CN4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("CN4 Title2").GetComponent<Text>().text = "CI";
                        if (tier == 2)
                        {
                            PlayerDeck.p4score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p4score += 2;
                        }
                        PlayerDeck.player4StackCards.Add(thisCard[0]);
                        PlayerDeck.player4Cards.Remove(thisCard[0]);
                        PlayerDeck.cn4 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer4Turn && this.tag != "CN" && this.tag != "Upgrade")
            {
                if (owner == "Discarded3")
                {
                    this.transform.SetParent(Discarded3.transform);
                }
                else
                {
                    this.transform.SetParent(Hand4.transform);
                }
            }
        }
        else if (summoned == false && this.transform.parent == stackZone4.transform) 
        {
            if (TurnSystem.isPlayer1Turn && (owner != "IT1" && owner != "Discarded4") && (this.tag == "IT" || this.tag == "Upgrade"))
            {
                if (stackZone4.transform.childCount > 2 && this.tag == "IT")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand.transform);
                }
                else
                {
                    owner = "IT1";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.it1);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT1 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT1 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("IT1 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("IT1 Title2").GetComponent<Text>().text = "IT";
                        if (tier == 2)
                        {
                            PlayerDeck.p1score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p1score += 2;
                        }
                        PlayerDeck.player1StackCards.Add(thisCard[0]);
                        PlayerDeck.player1Cards.Remove(thisCard[0]);
                        PlayerDeck.it1 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer1Turn && owner != "IT1" && this.tag != "IT" && this.tag != "Upgrade")
            {
                if (owner == "Discarded4")
                {
                    this.transform.SetParent(Discarded4.transform);
                }
                else
                {
                    this.transform.SetParent(Hand.transform);
                }
            }

            if (TurnSystem.isPlayer2Turn && (owner != "IT2" && owner != "Discarded1") && (this.tag == "IT" || this.tag == "Upgrade"))
            {
                if (stackZone4.transform.childCount > 1 && this.tag == "IT")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand2.transform);
                }
                else
                {
                    owner = "IT2";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.it2);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT2 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT2 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand2.transform);
                        }


                    }
                    else
                    {
                        GameObject.Find("IT2 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("IT2 Title2").GetComponent<Text>().text = "IT";
                        if (tier == 2)
                        {
                            PlayerDeck.p2score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p2score += 2;
                        }
                        PlayerDeck.player2StackCards.Add(thisCard[0]);
                        PlayerDeck.player2Cards.Remove(thisCard[0]);
                        PlayerDeck.it2 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer2Turn && owner != "IT2" && this.tag != "IT" && this.tag != "Upgrade")
            {
                if (owner == "Discarded1")
                {
                    this.transform.SetParent(Discarded1.transform);
                }
                else
                {
                    this.transform.SetParent(Hand2.transform);
                }
            }

            if (TurnSystem.isPlayer3Turn && (owner != "IT3" && owner != "Discarded2") && (this.tag == "IT" || this.tag == "Upgrade"))
            {
                if (stackZone4.transform.childCount > 1 && this.tag == "IT")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand3.transform);
                }
                else
                {
                    owner = "IT3";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.it3);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT3 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT3 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand3.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("IT3 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("IT3 Title2").GetComponent<Text>().text = "IT";
                        if (tier == 2)
                        {
                            PlayerDeck.p3score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p3score += 2;
                        }
                        PlayerDeck.player3StackCards.Add(thisCard[0]);
                        PlayerDeck.player3Cards.Remove(thisCard[0]);
                        PlayerDeck.it3 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer3Turn && owner != "IT3" && this.tag != "IT" && this.tag != "Upgrade")
            {
                if (owner == "Discarded2")
                {
                    this.transform.SetParent(Discarded2.transform);
                }
                else
                {
                    this.transform.SetParent(Hand3.transform);
                }
            }

            if (TurnSystem.isPlayer4Turn && (owner != "IT4" && owner != "Discarded3") && (this.tag == "IT" || this.tag == "Upgrade"))
            {
                if (stackZone4.transform.childCount > 1 && this.tag == "IT")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand4.transform);
                }
                else
                {
                    owner = "IT4";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.it4);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT4 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 14)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 15)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 16)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 17)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 BT");
                            }
                            else if (card.GetComponent<ThisCard>().id == 42)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 BT");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("IT4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("IT4 Title2").GetComponent<Text>().text = "IT";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand4.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("IT4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("IT4 Title2").GetComponent<Text>().text = "IT";
                        if (tier == 2)
                        {
                            PlayerDeck.p4score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p4score += 2;
                        }
                        PlayerDeck.player4StackCards.Add(thisCard[0]);
                        PlayerDeck.player4Cards.Remove(thisCard[0]);
                        PlayerDeck.it4 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer4Turn && owner != "IT4" && this.tag != "IT" && this.tag != "Upgrade")
            {
                if (owner == "Discarded3")
                {
                    this.transform.SetParent(Discarded3.transform);
                }
                else
                {
                    this.transform.SetParent(Hand4.transform);
                }
            }
        } 
        else if (summoned == false && this.transform.parent == stackZone5.transform)
        {
            if (TurnSystem.isPlayer1Turn && (owner != "VC1" && owner != "Discarded4") && (this.tag == "VC" || this.tag == "Upgrade"))
            {
                if (stackZone5.transform.childCount > 2 && this.tag == "VC")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand.transform);
                }
                else
                {
                    owner = "VC1";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.vc1);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC1 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC1 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC1 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p1score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("VC1 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("VC1 Title2").GetComponent<Text>().text = "VC";
                        if (tier == 2)
                        {
                            PlayerDeck.p1score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p1score += 2;
                        }
                        PlayerDeck.player1StackCards.Add(thisCard[0]);
                        PlayerDeck.player1Cards.Remove(thisCard[0]);
                        PlayerDeck.vc1 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer1Turn && owner != "VC1" && this.tag != "VC" && this.tag != "Upgrade")
            {
                if (owner == "Discarded4")
                {
                    this.transform.SetParent(Discarded4.transform);
                }
                else
                {
                    this.transform.SetParent(Hand.transform);
                }
            }

            if (TurnSystem.isPlayer2Turn && (owner != "VC2" && owner != "Discarded1") && (this.tag == "VC" || this.tag == "Upgrade"))
            {
                if (stackZone5.transform.childCount > 1 && this.tag == "VC")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand2.transform);
                }
                else
                {
                    owner = "VC2";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.vc2);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC2 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC2 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC2 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p2score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand2.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("VC2 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("VC2 Title2").GetComponent<Text>().text = "VC";
                        if (tier == 2)
                        {
                            PlayerDeck.p2score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p2score += 2;
                        }
                        PlayerDeck.player2StackCards.Add(thisCard[0]);
                        PlayerDeck.player2Cards.Remove(thisCard[0]);
                        PlayerDeck.vc2 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer2Turn && owner != "VC2" && this.tag != "VC" && this.tag != "Upgrade")
            {
                if (owner == "Discarded1")
                {
                    this.transform.SetParent(Discarded1.transform);
                }
                else
                {
                    this.transform.SetParent(Hand2.transform);
                }
            }


            if (TurnSystem.isPlayer3Turn && (owner != "VC3" && owner != "Discarded2") && (this.tag == "VC" || this.tag == "Upgrade"))
            {
                if (stackZone5.transform.childCount > 1 && this.tag == "VC")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand3.transform);
                }
                else
                {
                    owner = "VC3";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.vc3);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC3 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC3 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC3 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p3score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand3.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("VC3 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("VC3 Title2").GetComponent<Text>().text = "VC";
                        if (tier == 2)
                        {
                            PlayerDeck.p3score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p3score += 2;
                        }
                        PlayerDeck.player3StackCards.Add(thisCard[0]);
                        PlayerDeck.player3Cards.Remove(thisCard[0]);
                        PlayerDeck.vc3 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer3Turn && owner != "VC3" && this.tag != "VC" && this.tag != "Upgrade")
            {
                if (owner == "Discarded2")
                {
                    this.transform.SetParent(Discarded2.transform);
                }
                else
                {
                    this.transform.SetParent(Hand3.transform);
                }
            }


            if (TurnSystem.isPlayer4Turn && (owner != "VC4" && owner != "Discarded3" ) && (this.tag == "VC" || this.tag == "Upgrade"))
            {
                if (stackZone5.transform.childCount > 1 && this.tag == "VC")
                {
                    Debug.Log("Count is " + stackZone.transform.childCount);
                    this.transform.SetParent(Hand4.transform);
                }
                else
                {
                    owner = "VC4";
                    this.transform.SetAsLastSibling();
                    if (thisCard[0].id == 38)
                    {
                        GameObject card = GameObject.Find(PlayerDeck.vc4);
                        if (card.GetComponent<ThisCard>().tier == 1)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-2 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-2 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC4 Title").GetComponent<Text>().text = card.GetComponent<ThisCard>().cardName + " Tier " + card.GetComponent<ThisCard>().tier;
                            GameObject.Find("VC4 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else if (card.GetComponent<ThisCard>().tier == 2)
                        {
                            if (card.GetComponent<ThisCard>().id == 5)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("1-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 6)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("2-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 7)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("3-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 8)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("4-3 VC");
                            }
                            else if (card.GetComponent<ThisCard>().id == 43)
                            {
                                card.GetComponent<ThisCard>().thisSprite = Resources.Load<Sprite>("5-3 VC");
                            }
                            card.GetComponent<ThisCard>().tier++;
                            GameObject.Find("VC4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                            GameObject.Find("VC4 Title2").GetComponent<Text>().text = "VC";
                            Destroy(gameObject);
                            PlayerDeck.p4score++;
                        }
                        else
                        {
                            this.transform.SetParent(Hand4.transform);
                        }

                    }
                    else
                    {
                        GameObject.Find("VC4 Title").GetComponent<Text>().text = cardName + " Tier " + tier;
                        GameObject.Find("VC4 Title2").GetComponent<Text>().text = "VC";
                        if (tier == 2)
                        {
                            PlayerDeck.p4score += 1;
                        }
                        else if (tier == 3)
                        {
                            PlayerDeck.p4score += 2;
                        }
                        PlayerDeck.player4StackCards.Add(thisCard[0]);
                        PlayerDeck.player4Cards.Remove(thisCard[0]);
                        PlayerDeck.vc4 = gameObject.name;
                    }
                }
            }

            if (TurnSystem.isPlayer4Turn && owner != "VC4" && this.tag != "VC" && this.tag != "Upgrade")
            {
                if (owner == "Discarded3")
                {
                    this.transform.SetParent(Discarded3.transform);
                }
                else
                {
                    this.transform.SetParent(Hand4.transform);
                }
            }
            
        }
       
    }

    public void Summon()
    {
        this.transform.rotation = stackZone.transform.rotation;
        //summoned = true;
    }

}
