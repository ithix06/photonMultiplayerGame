using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {

	public int health = 100;
	public int maxHealth = 100;

	private float adjustment = 1f;
	private Vector3 worldPosition = new Vector3();
	private Vector3 screenPosition = new Vector3();
	//private Transform = GameObject.Transform;
	private Transform myTransform;
	private Camera myCamera;
	private int healthBarHeight = 3;
	private int healthBarLeft = 110;
	private int barTop = 1;
	private GUIStyle myStyle = new GUIStyle();
	private GameObject myCam;
	private float healthBarWidth = 100f;


	void Start () {
		myCam = GameObject.Find("Camera");
	}

	void OnGUI(){
		//GUI.HorizontalSlider(new Rect(25, 25, 100, 30), startingHealth, 0.0F, 100.0F);
		worldPosition = new Vector3(myTransform.position.x, transform.position.y, transform.position.z + adjustment);
		screenPosition = myCamera.WorldToScreenPoint(worldPosition);
		
		//creating a ray that will travel forward from the camera's position   
		//Ray ray = new Ray (myCam.transform.position, transform.forward);
		//RayCastHit hit;
		//Vector3 forward = transform.TransformDirection(Vector3.forward);
		//float distance = Vector3.Distance(myCam.transform.position, transform.position); //gets the distance between the camera, and the intended target we want to raycast to

		//if something obstructs our raycast, that is if our characters are no longer 'visible,' dont draw their health on the screen.
		//if (!Physics.Raycast(ray, hit, distance))
		if(true)
		{
			GUI.color = Color.red;
			GUI.HorizontalScrollbar(new Rect (screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop, healthBarWidth, 0), 0, health, 0, maxHealth); //displays a healthbar
			
			GUI.color = Color.white;
			GUI.contentColor = Color.white;                
			GUI.Label(new Rect(screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop+5, 100, 100), ""+health+"/"+maxHealth); //displays health in text format
		}
	}

	void Awake(){
		myTransform = transform;
		myCamera = Camera.main;

	}
	// Update is called once per frame
	void Update () {
		//var wantedPos = Camera.main.WorldToViewportPoint (transform.position);
		//transform.position = wantedPos;
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		
		if (stream.isWriting) {
			stream.SendNext(health);
		} 
		else {
			health = (int)stream.ReceiveNext();
		}
	}
}
