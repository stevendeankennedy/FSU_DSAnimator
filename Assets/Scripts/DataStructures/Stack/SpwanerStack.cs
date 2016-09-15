using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpwanerStack : MonoBehaviour {

    public StackPiece[] stackPieces;
    public int poolSize;
    int elementsWeRememberInStack = 0;
    int elementsCurrentlyInStacK;

    private LinkedList<StackPiece> pool;

	// Use this for initialization
	void Start () {

        pool = new LinkedList<StackPiece>();
        for (int i = 0; i < poolSize; i++)
        {
            int rNum = Random.Range(0, stackPieces.Length);
            StackPiece clone = Instantiate<StackPiece>(stackPieces[rNum]);
            clone.gameObject.SetActive(false);
            clone.transform.SetParent(this.transform);
            clone.transform.localPosition = Vector3.zero;
            pool.AddLast(clone);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        elementsCurrentlyInStacK  = StackManager.getCurrentStackManager().numberOfElements();
        if (elementsWeRememberInStack != elementsCurrentlyInStacK)
        {
            //something has changed in the stack, we need to animate it
            if (elementsWeRememberInStack > elementsCurrentlyInStacK)
            {
                //the stack is smaller "pop"
            }
            else
            {
                //the stack is bigger "push"
                Spawn();
                elementsWeRememberInStack = elementsCurrentlyInStacK;
            }
        }
    }

    // generates a stack piece
    void Spawn()
    {
        if (pool.Count == 0)
        {
            Debug.Log("Nothing left to spawn ...");
            return;
        }
        string newtext = StackManager.getCurrentStackManager().returnLastElement();
        StackPiece next = pool.First.Value;
        next.gameObject.SetActive(true);
        next.name = newtext;
       // next.changeText(newtext);
        pool.RemoveFirst();
    }

}
