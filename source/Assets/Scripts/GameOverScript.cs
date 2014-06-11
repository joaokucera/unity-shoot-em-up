using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private GUISkin newSkin;
	
	void Start()
	{
		newSkin = Resources.Load ("Menu Skin") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;
		
		GUI.skin = newSkin;

		// Reiniciando a fase!
		if (GUI.Button (
			new Rect (Screen.width / 2 - (buttonWidth / 2), 
		          (2 * Screen.height / 4) - (buttonWidth / 2),
		          buttonWidth, buttonHeight),
			"Retry!")) 
		{
			Application.LoadLevel("Level1");
		}

		// Voltar para o menu!
		if (GUI.Button (
			new Rect (Screen.width / 2 - (buttonWidth / 2), 
		          (2 * Screen.height / 2.5f) - (buttonWidth / 2),
		          buttonWidth, buttonHeight),
			"Menu!")) 
		{
			Application.LoadLevel("Menu");
		}
	}
}
