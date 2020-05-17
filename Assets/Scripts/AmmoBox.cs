using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public AudioSource ammoPickUpSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Gun gun = other.GetComponentInChildren<Gun>();
            // if (gun != null)
            Gun.ammo += 6f;

            ammoPickUpSound.Play();

            Destroy(gameObject);
        }
        if(Gun.ammo > 6f)
        {
            Gun.ammo = 6f;
        } 
    }
}
