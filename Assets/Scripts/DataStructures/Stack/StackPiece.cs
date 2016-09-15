using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StackPiece : MonoBehaviour {

    int indexNumber;
    TextMesh txt;
	// Use this for initialization
	void Start () {

        txt = GetComponentInChildren<TextMesh>();
        txt.text = "Empty";
	}

    void Update()
    {
        txt.text = name;
    }

    public void changeText(string newText)
    {
        txt.text = "";
        Debug.Log(newText);
        Debug.Log("what???");
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
