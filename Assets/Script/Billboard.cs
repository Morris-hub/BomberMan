using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    //Belomngs to Canvas

    public Transform cam;
    public bool BillboardMode = false;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void LateUpdate() {

    if(BillboardMode == true){
    transform.LookAt(transform.position + cam.forward);  
    }  
    }
}
