using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Vector3 maxAngle = new Vector3(280f,0f,290f);
    public Vector3 minAngle = new Vector3(280f,0f,270f);
    public float turnSpeed = 5f;
    public bool rotLeft = true;
    public bool rotate = false;
    public Winnings winnings;
    public ButtonFunctionality buttonFunctionality;

    public void Update()
    {
        
    }
    /// <summary>
    /// makes the chest spin slightly
    /// </summary>
    public void OnMouseOver()
    {
        if(!rotLeft)
        {
            this.transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * turnSpeed,Space.World);
            //Debug.Log(this.transform.rotation.eulerAngles.y + " >= " + (maxAngle.z -.5f));
            if(this.transform.rotation.eulerAngles.y >= maxAngle.z)
            {
                //Debug.Log("left");
                rotLeft = true;
            }
        }
        else
        {
            this.transform.Rotate(new Vector3(0,-1,0) * Time.deltaTime * turnSpeed,Space.World);
            //Debug.Log(this.transform.rotation.eulerAngles.z + " <= " + (minAngle.z -.5f));
            if(this.transform.rotation.eulerAngles.y <= minAngle.z)
            {
                //Debug.Log("right");
                rotLeft = false;
            }
        }
        
    }

    /// <summary>
    /// Opens a chest and gets the winnigns from it if there are any 
    /// </summary>
    public void OnMouseDown()
    {
       winnings.GetWinnings();
       buttonFunctionality.UpdatePlayButton();
    }
}
