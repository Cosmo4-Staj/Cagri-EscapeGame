using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private Touch touch;
    GameManager gameManager;
    public GameObject Planet;
    public float speed =4;
    public float gravity=100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 GroundNormal;
    private Rigidbody rb;

    private void Awake()
    {        
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameEnded) // Oyun bittiyse
        {
            return;
        }
        transform.Translate(Vector3.forward * (speed) * Time.deltaTime); // ileri dogru hareket


        if (Input.touchCount > 0) // Dokunma varsa;
        {
            touch = Input.GetTouch(0); // Degiskeni atama atama

            if (touch.phase == TouchPhase.Moved) // Dokunma basladiginda;
            {
                transform.Rotate(0f,touch.deltaPosition.x*0.2f,0f); //Dondur
            }
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
