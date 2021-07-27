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
        if (!GameManager.isGameStarted || GameManager.isGameEnded) // Oyun baslamadiysa veya bittiyse
        {
            return;
        }
        StartCoroutine(Spawner());
    }
    
    IEnumerator Spawner()
    {
        while(count<10)
        {
            xPos=  Random.Range(-20,20);
            yPos=  Random.Range(-20,20);
            zPos=  Random.Range(-20,20);
            Instantiate(meteor,new Vector3(xPos,yPos,zPos),Quaternion.identity);
            yield return new WaitForSeconds(1f);
            count+=1;
        }
    }
}
