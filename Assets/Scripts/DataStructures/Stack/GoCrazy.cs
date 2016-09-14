using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoCrazy : MonoBehaviour {

    public Text crazyText;

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoingCrazy()
    {
        string crazy = StackManager.getCurrentStackManager().toString();

       crazyText.text = "tttt "+crazy +"  It went crazy";
    }
}
