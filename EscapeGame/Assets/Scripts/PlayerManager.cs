using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Planet;
    public float speed =4;
    float gravity=100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 GroundNormal;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (speed) * Time.deltaTime); // ileri dogru hareket

        if (Input.GetKey(KeyCode.A))//sola donus
        {
            transform.Rotate(0,-150*Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.D))//saga donus
        {
            transform.Rotate(0,150*Time.deltaTime,0);
        }

        RaycastHit hit= new RaycastHit();
        if (Physics.Raycast(transform.position,-transform.up,out hit,10))
        {
            distanceToGround = hit.distance;
            GroundNormal= hit.normal;

            if (distanceToGround <=0.2f)
            {
                OnGround=true;
            }
            else
            {
                OnGround=false;
            }
        }
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
         if(OnGround==false)
         {
             rb.AddForce(gravDirection*-gravity);

         }
         Quaternion toRotation = Quaternion.FromToRotation(transform.up, GroundNormal)*transform.rotation;
         transform.rotation = toRotation;



    }
}
