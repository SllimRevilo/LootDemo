using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float openChestZValue = -13;
    [HideInInspector]
    public GameObject[] openChests;
    private int openChestIndex = 0;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;
    public GameObject chest4;
    public GameObject chest5;
    public GameObject chest6;
    public GameObject chest7;
    public GameObject chest8;
    public GameObject chest9;
    public GameObject openChest1;
    public GameObject openChest2;
    public GameObject openChest3;
    public GameObject openChest4;
    public GameObject openChest5;
    public GameObject openChest6;
    public GameObject openChest7;
    public GameObject openChest8;
    public GameObject openChest9;
    public GameObject pooper;
    private Vector3 offScreenValue = new Vector3(-20f,-20f,-13f);
    // Start is called before the first frame update
    void Start()
    {
        openChests = new GameObject[]{openChest1,openChest2,openChest3,openChest4,openChest5,openChest6,openChest7,openChest8,openChest9};
        this.ResetChests();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveOpenChest(Vector3 pos)
    {
        openChests[openChestIndex].transform.position = new Vector3(pos.x,pos.y,openChestZValue);
        openChestIndex++;
    }
    public void MovePooper(Vector3 pos)
    {
        pooper.transform.position = new Vector3(pos.x,pos.y,openChestZValue);
    }
    public void ResetChests()
    {
        openChestIndex=0;
        chest1.SetActive(true);
        chest2.SetActive(true);
        chest3.SetActive(true);
        chest4.SetActive(true);
        chest5.SetActive(true);
        chest6.SetActive(true);
        chest7.SetActive(true);
        chest8.SetActive(true);
        chest9.SetActive(true);
        foreach(GameObject chest in openChests)
        {
            chest.transform.position = offScreenValue;
        }
        pooper.transform.position = offScreenValue;
    }
}
