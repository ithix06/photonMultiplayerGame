using UnityEngine;
using System.Collections;

//GREAT TUTORIAL- http://clintonbrennan.com/2013/12/lockstep-implementation-in-unity3d/
//TODO: Character Slow Turning, Move Acceleration
public class UnitMovement : MonoBehaviour {

	public float speed = 5f;
	public float lerpConstant = 5f;
	PhotonView pv;
	private Vector3 correctPlayerPos;
	// Use this for initialization
	void Start () {
	
	}
	 
	void Awake(){
		pv = PhotonView.Get (this);
		correctPlayerPos = transform.position;
	}
	// Update is called once per frame
	void Update () {

		//Smooth Movement
		if (!pv.isMine)
		{
			//work?
			//transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * lerpConstant);
		}

		if(pv != null && pv.isMine){
			InputMovement ();
		}
	}

	void InputMovement(){
		if(Input.GetKey (KeyCode.W)){
			//rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey (KeyCode.S)){
			//rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}
		if(Input.GetKey (KeyCode.D)){
			//rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		if(Input.GetKey (KeyCode.A)){
			//rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		if (stream.isWriting) {
			stream.SendNext(transform.position);
			//stream.SendNext(transform.rotation);
			//stream.SendNext(velocity);
		} 
		else {
			//this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			transform.position = (Vector3)stream.ReceiveNext();
			//transform.rotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
