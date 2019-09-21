using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Kamera y ekseni haricinde diger eksenlerde hareket ediyor. Ve topumuzu takip ediyor
    void Update()
    {
        this.transform.position = new Vector3(GameObject.Find("Ball").transform.position.x, 0.6f, GameObject.Find("Ball").transform.position.z);
    }
}
