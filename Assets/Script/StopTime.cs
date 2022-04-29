using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{

    private bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) )
        {

            if(paused)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                paused = !paused;
            }

        }
    }
}
