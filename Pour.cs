using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{

    public Transform spout = null;
    public GameObject StreamOb = null;
    
    private bool IsPouring = false;




    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculateAngleDot() > 0;

        //checks if the bottle should currently be pouring based on the angle the bottle is at
            if (IsPouring != pourCheck)
            {
                IsPouring = pourCheck;
                //if it should be, it activates the StartPour(). If not it activates the EndPour
                if (IsPouring)
                {
                    StartPour();
                }
                else
                {
                    EndPour();
                }
            }
    }
    

    private void StartPour()
    {
        //sets the stream gameobject on the bottle active
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
    

    private void EndPour()
    {
        //deactivates teh stream object on the bottle
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    private float CalculateAngleDot()
    {
        //will check if the bottle is currently facing upwards or downwards
        return Vector3.Dot(transform.up, Vector3.down);
    }
}
