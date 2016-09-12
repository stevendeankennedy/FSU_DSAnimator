using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// This script is for the buttons in the menu screen. Each button will take the user to a different scene about a data structure.


public class ButtonMenuScreen : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void goToStack()
    {
        Application.LoadLevel("Stack");
    }

    public void goToQueue()
    {
        Application.LoadLevel("Queue");
    }

    public void goToBubbleSort()
    {
        Application.LoadLevel("BubbleSort");
    }

    public void goToLinearSearch()
    {
        Application.LoadLevel("Stack");
    }
}
