using UnityEngine;
using System.Collections;

public class StackManager : MonoBehaviour {

    // This list will represent the stack in the Stack Scene and it will contain all the elements that will be displayed in the scene
    public ArrayList mainStack = new ArrayList();
    int top = 0;
    public static StackManager currentStack;

    // Use this for initialization
    void Awake () {
        currentStack = this;
    }
    
    public static StackManager getCurrentStackManager()
    {
        if (!currentStack)
        {
            return null;
        }
        return currentStack;
    }

    //adds and element to the beggining of the stack
    public void push(object newElement)
    {
        if (newElement != null && newElement+"" != "")
        {
            getCurrentStackManager().mainStack.Add(newElement);
            top++;
        }
    }

    //removes the last element from the stack
    public void pop()
    {
        getCurrentStackManager().mainStack.RemoveAt(top-1);
        top--;
    }

    // returns the stack
    public ArrayList returnStack()
    {
        return getCurrentStackManager().mainStack;
    }

    //returns a string of elements of the stack ordered by index
    public string toString()
    {
        string stringToReturn="jbjbjb";
        for (int i = 0; i < getCurrentStackManager().mainStack.Count; i++)
        {
            stringToReturn += mainStack[i];
        }
        return stringToReturn;
    }

    public void resetStack()
    {
        getCurrentStackManager().mainStack.Clear();
        top = 0;
    }

    public bool isSTackEmpty()
    {
        bool isEmpty;
        if (top == 0)
        {
            isEmpty = true;
        }
        else
        {
            isEmpty = false;
        }
        return isEmpty;
    }

    public int returnTop()
    {
        return getCurrentStackManager().top;
    }
}
