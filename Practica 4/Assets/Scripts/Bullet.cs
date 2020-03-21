using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;
    private GameObject decalTMP;
    private RaycastHit rayCast;
    void OnCollisionEnter(Collision colision)
    {
        if (Physics.Raycast(transform.position, transform.forward, out rayCast, 10f))
        {
            decalTMP = Instantiate(decalPrefab, rayCast.point, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(decalTMP, 10);
        }
    }

}
