using UnityEngine;
using System.Collections;

public class UnitAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
	public int attackDamage = 10;               // The amount of health taken away per attack.
	PhotonView pv;

	GameObject player;
	private bool playerInRange = false;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		pv = PhotonView.Get (this);
		if (!pv.isMine) {
			Debug.Log(pv.name);
			player = pv.gameObject;

			//enabled = false;
		}
	}

	void OnCollisionEnter (Collision other)
	{
		Debug.Log ("ON Collider ENTER");
		gameObject.GetComponent<UnitHealth>().health--;
		//if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
