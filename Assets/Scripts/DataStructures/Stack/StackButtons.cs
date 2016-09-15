using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StackButtons : MonoBehaviour {

    public InputField input;
    public Text crazyText;
    public Text messageToUser;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // this method takes the content of the inputField and pushes it to the stack
    public void pushToStack()
    {
        if (input.text != null && input.text != "")
        {
            string stringToInput = input.text;
            StackManager.getCurrentStackManager().push(stringToInput);
        }
        else
        {
            messageToUser.text ="You need to type a value";
        }        
    }


    public void popFromStack()
    {
        if (StackManager.getCurrentStackManager().isSTackEmpty())
        {
            messageToUser.text = "The Stack is Empty";
        }
        else
        {
            StackManager.getCurrentStackManager().pop();
        }

    }

    public void GoingCrazy()
    {
        string crazy = StackManager.getCurrentStackManager().toString();

        crazyText.text = "tttt " + crazy + "  It went crazy   "+ StackManager.getCurrentStackManager().numberOfElements();
        messageToUser.text = "";
    }
}
