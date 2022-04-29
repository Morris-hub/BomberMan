using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zawarudo : MonoBehaviour
{


    public float slowdownFactor = 0.055f;
    public float slowdownLength = 2f;

    void DoSLowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //if(Input.GetKeyDown(KeyCode.Space)){

          DoSLowmotion();
        
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        
      //}
        
    }
}
