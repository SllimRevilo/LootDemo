using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    public Quaternion maxRotation = new Quaternion(260f,0f,300f,1f);
    public Quaternion minRotation = new Quaternion(260f,0f,220f,1f);
    public float turnSpeed = .0000000001f;
    private static Quaternion startRot = new Quaternion(260f,0f,260f,1f);
    private bool rotLeft = true;
    private bool rotate = false;

    public void Update()
    {
        while(rotate){

            if(rotLeft)
            {
                Debug.Log("original: " + chest.transform.rotation.eulerAngles);
                Vector3 rot = Quaternion.Lerp(chest.transform.rotation,minRotation,Time.deltaTime * this.turnSpeed).eulerAngles;
                Debug.Log("to: " + rot);
                this.chest.transform.rotation = Quaternion.Euler(startRot.x ,startRot.y,rot.z);
                Debug.Log(rot.z);

                if(this.chest.transform.rotation.eulerAngles.z <= minRotation.eulerAngles.z+.5f)
                {
                    rotLeft = false;
                }
            }
            else
            {
                Debug.Log(chest.transform.rotation.eulerAngles);
                Vector3 rot = Quaternion.Lerp(chest.transform.rotation,maxRotation,Time.deltaTime * this.turnSpeed).eulerAngles;
                this.chest.transform.rotation = Quaternion.Euler(startRot.x ,startRot.y,rot.z);

                if(this.chest.transform.rotation.eulerAngles.z >= maxRotation.eulerAngles.z+.5f)
                {
                    rotLeft = true;
                }
            }
        }
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
