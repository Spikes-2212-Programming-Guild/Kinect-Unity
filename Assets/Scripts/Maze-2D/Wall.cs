using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject[] wallArr;
    public GameObject player;
    public int wallArrNum;
    public float Px, Py, Pz;
    public float Bx1, By1;
    public float Bx2, By2;
    public float Bx, By;
    public double BRotat;
    


	// Use this for initialization
	void Start () {
         wallArrNum = 0;
        Bx = wallArr[wallArrNum].GetComponent<RectTransform>().position.x;
        By = wallArr[wallArrNum].GetComponent<RectTransform>().position.y;
        BRotat = wallArr[wallArrNum].GetComponent<RectTransform>().rotation.z;
        Px = player.GetComponent<Transform>().position.x;
        Py = player.GetComponent<Transform>().position.y;
        Pz = player.GetComponent<Transform>().position.z;
        Bx1 = Bx - wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.x/2;
        By1 = By - wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.y/2;
        Bx2 = Bx + wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.x/2;
        By2 = By + wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.y/2;

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Bx1);
        for (int i = 0; i <= 45; i++)
        {
            if (BRotat == 0)                         //Checks if the block is horizontal or vertical
            {
                if(Py<By1 && Py > By2)           //Checks if the Player is between the block's  Y edges
                {                       
                    if (Px < Bx1 && Px > Bx2)   //Checks if the Player is between the block's X edges
                    {
                        if (Px < Bx)            //Checks where is the Player within the block
                        {
                            Px += 1f;            //Gets the Player out of he block
                            break;
                        }
                    }
                }
            }
            if (BRotat == 0)
            {
                if (Py < By1 && Py > By2)
                {
                    if (Px < Bx1 && Px > Bx2)
                    {
                        if (Px > Bx)
                        {
                            Px -= 1f;
                            break;
                        }
                    }
                }
            }
            if (BRotat == 90)
            {
                if (Px < Bx1 && Px > Bx2)
                {
                    if (Py < By1 && Py > By2)
                    {
                        if (Py < By)
                        {
                            Py += 1f;
                            break;
                        }
                    }
                }
            }
            if (BRotat == 90)
            {
                if (Px < Bx1 && Px > Bx2)
                {
                    if (Py < By1 && Py > By2)
                    {
                        if (Py > By)
                        {
                            Py -= 1f;
                            break;
                        }
                    }
                }
            }
            wallArrNum++;
            Px = player.GetComponent<Transform>().position.x;
            Py = player.GetComponent<Transform>().position.y;
            Pz = player.GetComponent<Transform>().position.z;
            Bx1 = -wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.x/2;
            By1 = -wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.y/2;
            Bx2 = wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.x/2;
            By2 = wallArr[wallArrNum].GetComponent<RectTransform>().sizeDelta.y/2;
            Bx = wallArr[wallArrNum].GetComponent<RectTransform>().position.x;
            By = wallArr[wallArrNum].GetComponent<RectTransform>().position.y;
        }
        wallArrNum = 0;
        //for(int i = 0; i<=wallArr.Length; i++)  
        //      {
        //          if (player.GetComponent<Transform>().position.x == wallArr[wallArrNum].GetComponent<Transform>().position.x)
        //              x = player.GetComponent<Transform>().position.x + 0.1f;
        //              player.GetComponent<Transform>().position.Set(x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
        //          if (player.GetComponent<Transform>().position.y == wallArr[wallArrNum].GetComponent<Transform>().position.y)
        //              y = player.GetComponent<Transform>().position.y + 0.1f;
        //              player.GetComponent<Transform>().position.Set(player.GetComponent<Transform>().position.x, y, player.GetComponent<Transform>().position.z);
        //          wallArrNum++;
        //      }
    }
}
