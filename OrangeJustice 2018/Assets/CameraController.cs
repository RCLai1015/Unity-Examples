using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public Text winText;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//winText.transform.position = player.transform.position;
		transform.position = player.transform.position + offset;
		
		//screenPos = GetComponent<Camera>().WorldToScreenPoint(GetComponent<RectTransform>().position);
		//GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
		//fontSize.fontSize = 24;
		//Vector3 screenPos = GetComponent<Camera>().WorldToScreenPoint(player.transform.position);
		//GUI.Label(new Rect(1220, 20, 300, 50), "Position: "  + player.transform.position.ToString("F2"), fontSize);
		
	}
}
