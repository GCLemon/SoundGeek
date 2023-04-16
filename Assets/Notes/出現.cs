using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 出現 : MonoBehaviour
{
    void Update()
    {
        //[A]キーを押す
        if (Input.GetKeyDown(KeyCode.A))
        {
           this.tag="Respawn";
           GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
           this.tag="Untagged";
           GetComponent<Renderer>().material.color = new Color32(0, 176, 176, 82);
        }
        
    }
}
