using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Vector3 maxAngle = new Vector3(280f,0f,300f);
    public Vector3 minAngle = new Vector3(280f,0f,260f);
    public float turnSpeed = 50f;
    public bool rotLeft = true;
    public bool rotate = false;

    public void Update()
    {
        Debug.Log(this.transform.rotation.eulerAngles.y + " >= " + (maxAngle.z -.5f));
        if(rotate)
        {
            if(!rotLeft)
            {
                this.transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * turnSpeed,Space.World);
                Debug.Log(this.transform.rotation.eulerAngles.y + " >= " + (maxAngle.z -.5f));
                if(this.transform.rotation.eulerAngles.y >= maxAngle.z)
                {
                    Debug.Log("left");
                    rotLeft = true;
                }
            }
            else
            {
                this.transform.Rotate(new Vector3(0,-1,0) * Time.deltaTime * turnSpeed,Space.World);
                Debug.Log(this.transform.rotation.eulerAngles.z + " <= " + (minAngle.z -.5f));
                if(this.transform.rotation.eulerAngles.y <= minAngle.z)
                {
                    Debug.Log("right");
                    rotLeft = false;
                }
            }
        }
        // if(rotate)
        // {
        //     if(!rotLeft)
        //     {
        //         Quaternion min = Quaternion.Euler(minAngle);
                
        //         this.transform.rotation = Quaternion.Lerp(this.transform.rotation,min,Time.deltaTime * this.turnSpeed);
        //         if(this.transform.rotation.eulerAngles.z <= minAngle.z + .5f)
        //         {
        //             rotLeft = true;
        //         }
        //     }
        //     else
        //     {
        //         Quaternion max = Quaternion.Euler(maxAngle);
        //         this.transform.rotation = Quaternion.Lerp(this.transform.rotation,max,Time.deltaTime * this.turnSpeed);
        //         Debug.Log(this.transform.rotation.z + " >= " + (maxAngle.z -.5f));
        //         if(this.transform.rotation.eulerAngles.z >= maxAngle.z - .5f)
        //         {
        //             rotLeft = false;
        //         }
        //     }
            
        // }
    }
    public void OnMouseOver()
    {

        
    }

    public void OnMouseDown()
    {
        this.rotate = !this.rotate;
        this.Rotate();
        Debug.Log("i did this");
    }
    public void Rotate()
    {
        
    }
}
