﻿using UnityEngine;
using System.Collections;

public class RemoveMobileGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
		Destroy(this.gameObject);
		#endif
	}

}
