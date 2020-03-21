using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject tmpBullet; 
    public float forceBullet;
    public bool isActive = false;
    private RaycastHit rayCast;
    public Image crosshair;
    public Camera fpsCam;
    public float dañoBala;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            tmpBullet = Instantiate(bulletPrefab,
                    transform.position,
                    Quaternion.identity);
            tmpBullet.transform.up = transform.forward;
            tmpBullet.GetComponent<Rigidbody>().AddForce(
                            transform.forward * forceBullet,
                            ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(){
       Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayCast, 10f);
                Instantiate(crosshair, rayCast.point, Quaternion.identity);
            
    }
}
