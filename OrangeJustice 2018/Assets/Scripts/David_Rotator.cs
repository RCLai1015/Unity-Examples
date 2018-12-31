using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables{
	public static float david_rotatespeed = 1;
}
public class David_Rotator : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime * GlobalVariables.david_rotatespeed);
	}
}