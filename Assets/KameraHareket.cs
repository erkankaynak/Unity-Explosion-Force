using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    public Transform tank; // Tankýn pozisyonunu referans olarak alýyoruz. 
    public float zOffset; // Kamera, tanktan Z düzleminde ne kadar uzakta olacak.

    void Update()
    {
        // x: Tankýn x koordinatý.
        // y: Kameranýn y koordinatý. Bu sabit kalýyor. 
        // z: Tankýn z koordinatýndan zOffset kadar uzakta. 

        transform.position = new Vector3(tank.position.x, transform.position.y, tank.position.z - zOffset);   
    }
}
