using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {
	
	public string levelToLoad;

	public void NewGame(){
		
		SceneManager.LoadScene(levelToLoad);
	}
}