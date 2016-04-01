using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {

	public Texture backgroundTexture;
	public Rect rect  = new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f);
	public string desc = "안녕하세요";
	public string levelToLoad = "New Level 1";

	void OnGUI(){

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		if(GUI.Button (rect, desc)){
			
			print ("ALLAHU AKBAR");

			SceneManager.LoadScene(levelToLoad);
		}
	}
}
