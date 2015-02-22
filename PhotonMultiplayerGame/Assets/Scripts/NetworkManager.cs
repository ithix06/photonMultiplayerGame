using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("alpha 0.1");
	}
	
	// Update is called once per frame
	//void Update () { }

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom ("room1");
	}

	void OnJoinedRoom(){
		if(PhotonNetwork.playerList.Length == 1){
			GameObject unit = PhotonNetwork.Instantiate ("Warrior", new Vector3(-2,0,0), Quaternion.identity, 0);
			unit.name = "firstIn";
		    //((MonoBehaviour)unit.GetComponent ("UnitMovement")).enabled = true;
		}

		else{	
			GameObject unit = PhotonNetwork.Instantiate ("Warrior", new Vector3(2,0,0), Quaternion.identity, 0);
			unit.name = "secondIn";
			//((MonoBehaviour)unit.GetComponent ("UnitMovement")).enabled = true;
		}
		
	}
}
