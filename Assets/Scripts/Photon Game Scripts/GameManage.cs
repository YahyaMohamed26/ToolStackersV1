using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class GameManage : MonoBehaviourPunCallbacks
{
   // public GameObject Hand, Hand2, Hand3, Hand4;
    public int toolDeckSize = 25;
    public int eventDeckSize = 20;
    public static int sToolDeckSize = 25;
    public static int sEventDeckSize = 20;
    public List<GameObject> toolCardsDeck = new List<GameObject>();
    public List<GameObject> eventCardsDeck = new List<GameObject>();
    public static List<GameObject> sToolCardsDeck = new List<GameObject>();
    public static List<GameObject> sEventCardsDeck = new List<GameObject>();
    public Text p1Name, p2Name, p3Name, p4Name;
   // public GameObject StackZone, StackZone2, StackZone3, StackZone4, StackZone5;
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < toolDeckSize; i++)
        {
            GameObject temp = toolCardsDeck[i];
            int randomIndex = Random.Range(i, toolDeckSize);
            toolCardsDeck[i] = toolCardsDeck[randomIndex];
            toolCardsDeck[randomIndex] = temp;
        }

        for (int i = 0; i < eventDeckSize; i++)
        {
            GameObject temp = eventCardsDeck[i];
            int randomIndex = Random.Range(i, eventDeckSize);
            eventCardsDeck[i] = eventCardsDeck[randomIndex];
            eventCardsDeck[randomIndex] = temp;
        }

        for(int i =0; i<PhotonNetwork.CountOfPlayers; i++)
        {
            if (i == 0)
            {
                p1Name.text = PhotonNetwork.PlayerList[i].NickName;
            }
            else if (i == 1)
            {
                p2Name.text = PhotonNetwork.PlayerList[i].NickName;
            }
            else if (i == 2)
            {
                p3Name.text = PhotonNetwork.PlayerList[i].NickName;
            }
            else if (i == 3)
            {
                p4Name.text = PhotonNetwork.PlayerList[i].NickName;
            }
        }
    }

    private void Update()
    {
        toolDeckSize = sToolDeckSize;
        eventDeckSize = sEventDeckSize;
        sToolCardsDeck = toolCardsDeck;
        sEventCardsDeck = eventCardsDeck;
        // toolCardsDeck = sToolCardsDeck;
        //  eventCardsDeck = sEventCardsDeck;
    }
    
}
