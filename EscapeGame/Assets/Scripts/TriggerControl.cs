using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Meteor")) //Arac Meteora carpti mi?
        {
            GameManager.instance.OnLevelFailed();
            //FindObjectOfType<AudioManager>().PlaySound("PickUpPart");
            //Destroy(other.gameObject); // yem'i yok et
            //CandleScale.instance.GetPartOfMum(); //fonk. cagir
        }

    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
