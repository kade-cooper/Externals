using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript1 : MonoBehaviour
{
    public float shoveImpulse;
    public headScriptBouncer head;
    public GameObject blood;
    public bool hasBeenHit=false;
    public playerMovementScript player;
    public float bounce;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag=="hammer")
        {
            Debug.Log("collided with shove");
            this.GetComponent<Rigidbody>().AddForce(collision.transform.forward*shoveImpulse);
            Instantiate(blood, head.transform.position, Quaternion.identity);
            Destroy(head.gameObject);
            hasBeenHit = true;
        }
        else if (collision.gameObject.tag == "stomp" && hasBeenHit)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovementScript>();
            player.velocity += new Vector3(0, bounce, 0);
            Instantiate(blood, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

}
