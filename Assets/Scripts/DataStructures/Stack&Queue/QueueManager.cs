using UnityEngine;
using System.Collections;

public class QueueManager : MonoBehaviour {

	public Queue queueList;

	public static QueueManager currentStack;

	// Use this for initialization
	void Awake () {
		currentStack = this;
	}

	public static QueueManager getQueueManager()
	{
		if (!currentStack)
		{
			return null;
		}
		return currentStack;
	}

	// this method takes the content of the inputField and pushes it to the stack
	public void enQueue(string input)
	{
		getQueueManager().queueList.Enqueue(input);     
	}


	public void deQueue()
	{
		getQueueManager().queueList.dequeue();
	}

	public void resetQueue() //pop everything
	{
		getQueueManager().queueList.resetQueue();
	}
}
