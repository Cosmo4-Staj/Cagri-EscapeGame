using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

	public float smoothness = 1f;
	
    public Vector3 offset;

    void LateUptade (){

        transform.position = target.position+offset;
    }
}
