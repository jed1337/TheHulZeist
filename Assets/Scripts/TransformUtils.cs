using UnityEngine;
using System.Collections;

public static class TransformUtils{
	public static void FlipArt(Transform trans) {
		Vector3 currRot = trans.eulerAngles;
		currRot.y += 180;
		trans.eulerAngles = currRot;
	}

}
