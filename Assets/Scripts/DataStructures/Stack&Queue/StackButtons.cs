using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StackButtons : GeneralGUIButtons {

  
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

	public void resetStack() //pop everything
	{
		if (StackManager.getCurrentStackManager().isSTackEmpty())
		{
			messageToUser.text = "The Stack is Empty";
		}
		else
		{
			StackManager.getCurrentStackManager().resetStack();
		}

	}
}
