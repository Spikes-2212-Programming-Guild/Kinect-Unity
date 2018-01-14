using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInput : MonoBehaviour {

	public bool jumpButton;
    public bool rightButton;
    public bool resetButton;
    public bool forwardButton;
    public bool backwardButton;
    public bool leftButton;
	public float absoultValueX;
	public float absoultValueY;
	public bool isStanding;
	public float standingThresHold = 1;

    // Use this for initialization
    void Awake()
    {
    }

	void Update () 
	{
        jumpButton = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow));
        rightButton = Input.GetKeyDown(KeyCode.RightArrow);
        leftButton = Input.GetKeyDown(KeyCode.LeftArrow);
        forwardButton = Input.GetKey(KeyCode.UpArrow);
        backwardButton = Input.GetKey(KeyCode.DownArrow);
        resetButton = Input.GetKey(KeyCode.R);
	}
	/*change values to be positve*/
	

}
