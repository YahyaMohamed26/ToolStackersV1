using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text sizeText;

    private string roomName;
    private int playerCount;

    public void JoinRoomClick()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetRoom(string nameInput, int countInput)
    {
        roomName = nameInput;
        playerCount = countInput;
        nameText.text = nameInput;
        sizeText.text = countInput + "/" + 4;
    }
}
