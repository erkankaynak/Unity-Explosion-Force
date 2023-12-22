using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TankHareket : MonoBehaviour
{
    public float hareketHiz;
    public float mermiHiz;

    public Transform namluUcu; // Merminin ��k�� noktas�
    public Rigidbody mermi;    // Mermi Prefab� i�in referans. Prefab i�erisinde Rigidbody bulundu�u i�in direk bu �ekilde referans verebiliriz.

    void Update()
    {
        // Tank W,A,S,D tu�lar� ile �nce y�n�n� belirleyecek, sonra ileri (Vector3.forward) y�n�nde ilerleyecek.
        // E�er hareket tu�lar�na bas�lm�yorsa hareket etmeyecek. 
        // Space tu�u ile ate� edece�iz.

        bool hareket = false; // Tu�lara bas�ld���nda hareketi kontrol etmek i�in. 

        if (Input.GetKey(KeyCode.W)) { hareket = true; transform.rotation = Quaternion.Euler(0, 0, 0); } // Tank ileriye do�ru bak�yor.
        if (Input.GetKey(KeyCode.A)) { hareket = true; transform.rotation = Quaternion.Euler(0, -90, 0); } // Tank sa� tarafa bak�yor.
        if (Input.GetKey(KeyCode.S)) { hareket = true; transform.rotation = Quaternion.Euler(0, 180, 0); } // Tank geriye do�ru bak�yor.
        if (Input.GetKey(KeyCode.D)) { hareket = true; transform.rotation = Quaternion.Euler(0, 90, 0); } // Tank sol tarafa bak�yor.

        if (hareket)
        {
            transform.Translate(Vector3.forward * hareketHiz * Time.deltaTime); // �leri y�nde hareket h�z�yla ilerle.
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate ( Yarat�lacak_Olan_Prefab, Yarataca��m�z_Pozisyon (Vector3), Nesnenin Rotasyonu)
            var mermiRB = Instantiate(mermi, namluUcu.position, Quaternion.identity); 

            // .AddForce(Y�n_ve_G��, G�c�n_Uygulanma_�ekli)
            // .TransformDirection : Tank�m�z�n y�n�n� (local) , d�nyadakine (world) �evirir.
            mermiRB.AddForce(transform.TransformDirection(Vector3.forward * mermiHiz), ForceMode.Impulse);
            
            // Mermiyi 1 saniye sonra yoket.
            Destroy(mermiRB.gameObject, 1f);
        }

        
    }


}
