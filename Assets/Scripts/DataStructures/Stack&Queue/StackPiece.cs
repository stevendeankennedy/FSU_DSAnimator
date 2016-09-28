using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StackPiece : MonoBehaviour {

	// int used to keep track of the index inside the stack
    public int indexNumber = 99;
   	// this is used to change the text that is being displayed in the game object 
	TextMesh txt;


	// Use this for initialization
	void Start () {
		// this are the default values. This changes the text to "empty" in the textmesh
        txt = GetComponentInChildren<TextMesh>();
        txt.text = "Empty";
	}

    void Update()
    {
		// this changes the text value of the TextMesh to the name of the object
		// the name of the object will be the same as the value it would hold in the stack
        txt.text = name;
    }

    public void setIndex(int newIndex)
    {
        indexNumber = newIndex;
    }

    public int getIndex()
    {
        return indexNumber;
    }

    public string getText()
    {
        return txt.text;
    }
}
