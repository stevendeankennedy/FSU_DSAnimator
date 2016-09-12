using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoCrazy : MonoBehaviour {

    public Text crazyText;
    int[] testArray;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoingCrazy()
    {
        crazyText.text = "It went crazy";
    }
}
