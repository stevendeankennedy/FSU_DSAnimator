using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QueueButtons : GeneralGUIButtons {

	// this method takes the content of the inputField and pushes it to the stack
	public void enQueue()
	{
		if (input.text != null && input.text != "")
		{
			string stringToInput = input.text;
			QueueManager.getQueueManager ().enQueue (stringToInput);
		}
		else
		{
			messageToUser.text ="You need to type a value";
		}        
	}


	public void deQueue()
	{
		if (QueueManager.getQueueManager().queueList.isEmpty())
		{
			messageToUser.text = "The Queue is Empty";
		}
		else
		{
			QueueManager.getQueueManager ().deQueue ();
		}
	}

	public void resetQueue() //pop everything
	{
		if (QueueManager.getQueueManager().queueList.isEmpty())
		{
			messageToUser.text = "The Queue is Empty";
		}
		else
		{
			QueueManager.getQueueManager().resetQueue();
		}

	}
}
