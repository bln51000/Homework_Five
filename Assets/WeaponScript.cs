using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float shootRange = 10f;
    //[SerializeField] ParticleSystem muzzleFlash;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

/*
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
*/
    private void Shoot(){
        //PlayMuzzleFlash();//invokes muzzle flash
        RaycastHit hit;

        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, shootRange))
        {
            Debug.Log("I hit an object");
        }
        else
        {
            return;
        }
    }
}
