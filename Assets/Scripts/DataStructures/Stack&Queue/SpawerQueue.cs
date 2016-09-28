using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawerQueue : MonoBehaviour {

	//Will containe different types of chest (same function different sprite)
	public StackPiece[] QueueCars;
	//the maximun size of the stack
	public int poolSize;
	int elementsWeRememberInStack = 0;
	int elementsCurrentlyInStacK;
	public StackPiece[] cars;

	public GameObject Spawner;
	public GameObject[] stackinground = new GameObject[5];

	//positions for the spawer
	public Vector3 originalPosition;
	public Vector3 secondPosition;
	public Vector3 thirdPosition;
	public Vector3 fourthPosition;
	public Vector3 fifthPosition;

	public Vector3 currentPosition;


	// this list will contain the pieces (chest/gameobject) that will represent each part of the stack
	private LinkedList<StackPiece> pool;


	// Use this for initialization
	void Start () {
	
		currentPosition = originalPosition;

		//we fill the list with empty stackpieces with default information.
		pool = new LinkedList<StackPiece>();
		for (int i = 0; i < poolSize; i++)
		{
			int rNum = Random.Range(0, QueueCars.Length);
			StackPiece clone = Instantiate<StackPiece>(QueueCars[rNum]);
			clone.gameObject.SetActive(false);
			clone.transform.SetParent(this.transform);
			clone.transform.position = currentPosition;
			pool.AddLast(clone);
		}
		for (int i = 1; i < 5; i++) 
		{
			stackinground [i].gameObject.SetActive (false);
		}
	}


	// Update is called once per frame
	void Update ()
	{
		// this will constantly check if the user uses the pop or push function in the GUI
		elementsCurrentlyInStacK  = QueueManager.getQueueManager().queueList.size();
		if (elementsWeRememberInStack != elementsCurrentlyInStacK)
		{
			//something has changed in the stack, we need to animate it
			if (elementsWeRememberInStack > elementsCurrentlyInStacK)
			{
				if (elementsCurrentlyInStacK == 0)
				{
					//if there are zero elements in the stack either the stack was reset or
					// the user poped the last element.
					cleanStack ();
					elementsWeRememberInStack = elementsCurrentlyInStacK;

				} else {

					//the stack is smaller "pop"
					DeSpawn ();
					elementsWeRememberInStack = elementsCurrentlyInStacK;
				}
			}
			else
			{
				//the stack is bigger "push"
				Spawn(); //this method activates one of the pieces that was created beforehand
				elementsWeRememberInStack = elementsCurrentlyInStacK;
			}
		}

		Spawner.transform.position = originalPosition;

		//this will keep track if we need to move to another stack hole image (moving the spawnner)
		if (elementsCurrentlyInStacK <8) 
		{

			currentPosition = originalPosition;
			for (int i = 1; i < 5; i++) 
			{
				stackinground [i].gameObject.SetActive (false);
			}
		} 
		else if(elementsCurrentlyInStacK <16)
		{
			stackinground [1].gameObject.SetActive (true);
			currentPosition = secondPosition;
			for (int i = 2; i < 5; i++) 
			{
				stackinground [i].gameObject.SetActive (false);
			}
		}
		else if(elementsCurrentlyInStacK <24)
		{
			stackinground [2].gameObject.SetActive (true);
			currentPosition = thirdPosition;
			for (int i = 3; i < 5; i++) 
			{
				stackinground [i].gameObject.SetActive (false);
			}
		}
		else if(elementsCurrentlyInStacK <32)
		{
			stackinground [3].gameObject.SetActive (true);
			currentPosition = fourthPosition;
			stackinground [4].gameObject.SetActive (false);
		}
		else
		{
			stackinground [4].gameObject.SetActive (true);
			currentPosition = fifthPosition;
		}
	}

	// activates a stack piece and changes its name this also chaning the value that it displays
	void Spawn()
	{
		//if the list is empty (we reached the limit of the stack) we will display this debug message
		if (pool.Count == 0)
		{
			Debug.Log("Nothing left to spawn ...");
			return;
		}
		// this line obtains the value that the newest element in the stack has
		string newtext = QueueManager.getQueueManager().queueList.last();
		// this gets the first stackpiece object that is store in the list
		StackPiece next = pool.First.Value;
		// the following two lines active the piece and changes its name to 
		// the text of the last piece inserted into the stack respectively
		next.transform.position = currentPosition;
		next.gameObject.SetActive(true);
		next.name = newtext;
		// We assign to the piece the same index number it would have in the stack so we can find it later
		next.setIndex (StackManager.getCurrentStackManager().numberOfElements()-1);
		// the stackpiece is removed from the stack list pool
		pool.RemoveFirst();
	}

	void DeSpawn()
	{
		StackPiece tobeRemoved;
		cars = GetComponentsInChildren<StackPiece>();
		for (int i = 0; i < cars.Length-1; i++) 
		{
			cars [i].name = cars [i + 1].name;
		}
		foreach (StackPiece tempPiece in cars)
		{
			if(tempPiece.getIndex()==QueueManager.getQueueManager().queueList.size())
			{
				tobeRemoved = tempPiece;
				tobeRemoved.gameObject.SetActive(false);
				tobeRemoved.transform.position = currentPosition;
				pool.AddLast (tobeRemoved);
			}
		}
	}

	void cleanStack()
	{
		StackPiece tobeRemoved;
		cars = GetComponentsInChildren<StackPiece>();
		foreach (StackPiece tempPiece in cars)
		{
			tobeRemoved = tempPiece;
			tobeRemoved.gameObject.SetActive(false);
			tobeRemoved.transform.position = currentPosition;
			pool.AddLast (tobeRemoved);
		}
	}
}
