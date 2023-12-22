using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TankHareket : MonoBehaviour
{
    public float hareketHiz;
    public float mermiHiz;

    public Transform namluUcu; // Merminin çýkýþ noktasý
    public Rigidbody mermi;    // Mermi Prefabý için referans. Prefab içerisinde Rigidbody bulunduðu için direk bu þekilde referans verebiliriz.

    void Update()
    {
        // Tank W,A,S,D tuþlarý ile önce yönünü belirleyecek, sonra ileri (Vector3.forward) yönünde ilerleyecek.
        // Eðer hareket tuþlarýna basýlmýyorsa hareket etmeyecek. 
        // Space tuþu ile ateþ edeceðiz.

        bool hareket = false; // Tuþlara basýldýðýnda hareketi kontrol etmek için. 

        if (Input.GetKey(KeyCode.W)) { hareket = true; transform.rotation = Quaternion.Euler(0, 0, 0); } // Tank ileriye doðru bakýyor.
        if (Input.GetKey(KeyCode.A)) { hareket = true; transform.rotation = Quaternion.Euler(0, -90, 0); } // Tank sað tarafa bakýyor.
        if (Input.GetKey(KeyCode.S)) { hareket = true; transform.rotation = Quaternion.Euler(0, 180, 0); } // Tank geriye doðru bakýyor.
        if (Input.GetKey(KeyCode.D)) { hareket = true; transform.rotation = Quaternion.Euler(0, 90, 0); } // Tank sol tarafa bakýyor.

        if (hareket)
        {
            transform.Translate(Vector3.forward * hareketHiz * Time.deltaTime); // Ýleri yönde hareket hýzýyla ilerle.
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate ( Yaratýlacak_Olan_Prefab, Yaratacaðýmýz_Pozisyon (Vector3), Nesnenin Rotasyonu)
            var mermiRB = Instantiate(mermi, namluUcu.position, Quaternion.identity); 

            // .AddForce(Yön_ve_Güç, Gücün_Uygulanma_Þekli)
            // .TransformDirection : Tankýmýzýn yönünü (local) , dünyadakine (world) çevirir.
            mermiRB.AddForce(transform.TransformDirection(Vector3.forward * mermiHiz), ForceMode.Impulse);
            
            // Mermiyi 1 saniye sonra yoket.
            Destroy(mermiRB.gameObject, 1f);
        }

        
    }


}
