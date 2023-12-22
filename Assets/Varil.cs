using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Varil : MonoBehaviour
{
    public float patlamaCapi = 5.0F;
    public float patlamaGucu = 10.0F;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mermi"))
        {

            Collider[] kutular = Physics.OverlapSphere(transform.position, 3f); // 10f çapýndaki her collider içeren nesneyi bulup hepsini bir diziye aktar.

            // Bir önceki iþlemde diziye aktardýðýmýz nesnelere sýrayla ExplosionForce uyguluyoruz.
            foreach (var kutu in kutular)
            {
                var rb = kutu.GetComponent<Rigidbody>();

                if (rb != null) // Nesnede Rigidboyd varsa 
                {
                    rb.AddExplosionForce(patlamaGucu, transform.position, patlamaCapi, 3.0F, ForceMode.Impulse);
                }
                    
            }

        }
    }

}
