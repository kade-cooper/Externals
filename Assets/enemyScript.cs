using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float shoveImpulse;
    public headScript head;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="shove")
        {
            Debug.Log("collided with shove");
            this.GetComponent<Rigidbody>().AddForce(collision.transform.forward*shoveImpulse);
            head.hasBeenShoved = true;
        }

    }

}
