using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public AudioSource gunSound;
    public float force = 100;

    //[SerializeField]
    public static float ammo = 6f;
    public AudioSource emptyClip;
    public Animator cameraAnimator;
    public Animator shottyAnimator;

    public ParticleSystem muzzleFlash;
    

    #region Ammo
    public GameObject ammo1;
    public GameObject ammo2;
    public GameObject ammo3;
    public GameObject ammo4;
    public GameObject ammo5;
    public GameObject ammo6;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            shottyAnimator.SetBool("isShot", true);
        }
        else
        {
            shottyAnimator.SetBool("isShot", false);
        }
        #region AmmoIcon
        if (ammo == 6)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
            ammo5.SetActive(true);
            ammo6.SetActive(true);
        }
           
        if (ammo == 5)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
            ammo5.SetActive(true);
            ammo6.SetActive(false);
        }
        if (ammo == 4)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
            ammo5.SetActive(false);
            ammo6.SetActive(false);
        }
        if (ammo == 3)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
            ammo6.SetActive(false);
        }
        if (ammo == 2)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
            ammo6.SetActive(false);
        }
        if (ammo == 1)
        {
            ammo1.SetActive(true);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
            ammo6.SetActive(false);
        }
        if (ammo == 0)
        {
            ammo1.SetActive(false);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
            ammo5.SetActive(false);
            ammo6.SetActive(false);
        }
        #endregion

        if(Input.GetButton("Fire2"))
        {
            cameraAnimator.SetBool("isZoomed", true);
        }
        else
        {
            cameraAnimator.SetBool("isZoomed", false);
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            

            gunSound.Play();

            muzzleFlash.Play();

            ammo -= 1;

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                TestTarget target = hit.transform.GetComponent<TestTarget>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    Debug.Log("Box Hit");
                }

                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log(" Hit Enemy");
                }
            }
           
        }
        else
        {
            emptyClip.Play();
            
        }
        
        

    }

   
}

