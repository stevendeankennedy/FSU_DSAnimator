using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Queue : MonoBehaviour {

	// This array will represent the Queue
	static int sizeOfList = 50;
	public string[] mainList = new string[sizeOfList];
	int nElements = 0; // numberOfElements
	int head = 0; // first index
	int indexToInsertTo;

	public static Queue currentQueue;

	// Use this for initialization
	void Awake () {
		currentQueue = this;
	}

	public static Queue getcurrentQueue()
	{
		if (!currentQueue)
		{
			return null;
		}
		return currentQueue;
	}

	//adds and element at the tail
	public void Enqueue(string newElement)
	{
		Debug.Log ("Adding to Queue");
		Debug.Log ("nElements is: "+nElements);
		Debug.Log ("head is: "+head);

		//queue is full
		if (nElements == sizeOfList - 1) {
			//do nothing
		} else {
			indexToInsertTo = (nElements + head)%sizeOfList;
			Debug.Log ("indexToInsertTo is: "+indexToInsertTo);
			mainList[indexToInsertTo]=newElement;
			nElements = nElements + 1;
		}
	}

	public string dequeue()
	{
		if (isEmpty ()) {
			return null;
		} else {
			string elementBeingReturned = mainList[head];
			mainList [head] = null;
			head = (head + 1) % sizeOfList;
			nElements = nElements - 1;
			return elementBeingReturned;
		}
	}

	public string first()
	{
		string firstElement=mainList[head];
		return firstElement;
	}

	public string last()
	{
		string lastElement=mainList[indexToInsertTo];
		return lastElement;
	}

	public int size()
	{
		return nElements;
	}

	public bool isEmpty()
	{
		if (nElements == 0)
		{
			return true;
		}else 
		{
			return false;
		}
	}

	public void resetQueue()
	{
		Debug.Log ("Reseting the queue");
		for (int i = 0; i < sizeOfList; i++) {
		
			getcurrentQueue ().mainList [i] = null;
		}
		nElements = 0; // numberOfElements
		head = 0; // first index
	}
}
