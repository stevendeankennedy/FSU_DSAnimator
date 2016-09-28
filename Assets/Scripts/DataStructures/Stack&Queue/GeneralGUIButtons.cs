using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneralGUIButtons : MonoBehaviour {

	public InputField input;
	public Text messageToUser;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void goToMenu()
	{
		Application.LoadLevel("Menu");
	}

}
