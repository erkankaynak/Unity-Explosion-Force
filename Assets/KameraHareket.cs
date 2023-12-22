using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    public Transform tank; // Tank�n pozisyonunu referans olarak al�yoruz. 
    public float zOffset; // Kamera, tanktan Z d�zleminde ne kadar uzakta olacak.

    void Update()
    {
        // x: Tank�n x koordinat�.
        // y: Kameran�n y koordinat�. Bu sabit kal�yor. 
        // z: Tank�n z koordinat�ndan zOffset kadar uzakta. 

        transform.position = new Vector3(tank.position.x, transform.position.y, tank.position.z - zOffset);   
    }
}
