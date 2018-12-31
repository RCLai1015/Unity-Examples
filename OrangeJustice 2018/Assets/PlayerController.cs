using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	public float speed; // Sphere Speed
	public float jumpSpeed = 3; // 跳躍速度
	public Text countText;
	public Text winText;
	public LayerMask groundLayers;
	public GameObject player;
	public SphereCollider col;
	private Rigidbody rb;
	private int count; // 計分
	private bool onGround = true; // 落地才能再次起跳
	private bool wantsToJump; // 不要每次跳的高度不一樣

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<SphereCollider>();
		count = 0;
		SetCountText();
		winText.text = "";
	}
	void Update(){
		if (Input.GetButtonDown("Jump")){
			wantsToJump = true;
		}

	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,0.0f, moveVertical);
		rb.AddForce (movement * speed);

		if (wantsToJump)
		{
			if (IsGrounded()) 
			{
				rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
			}
			wantsToJump = false;
		}

	}
	private bool IsGrounded()
	{
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
		col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}	
	void OnTriggerEnter(Collider other)
    {		
	
        if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			GlobalVariables.david_rotatespeed = GlobalVariables.david_rotatespeed + 2;
			SetCountText();
			
		}
    }

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
		{
			winText.text = "Collected ALL THE DAVID !";
		}
	}
}
