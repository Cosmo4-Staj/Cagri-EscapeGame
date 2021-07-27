using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    GameManager gameManager;
    public GameObject meteor;
    public int xPos;
    public int yPos;
    public int zPos;
    public int count;

    void Start()
    {
        //StartCoroutine(Spawner());
    }
    
    void Update()
    {
    if (!GameManager.isGameStarted || GameManager.isGameEnded) // Oyun baslamadiysa veya bittiyse
        {
            return;
        }
        while(count<10)
        {
            xPos=  Random.Range(-20,20);
            yPos=  Random.Range(-20,20);
            zPos=  Random.Range(-20,20);
            Instantiate(meteor,new Vector3(xPos,yPos,zPos),Quaternion.identity);
            StartCoroutine(Spawner());
            count+=1;
        }
    


    }
    IEnumerator Spawner()
    {
            yield return new WaitForSeconds(seconds: 3); 
    }
}
