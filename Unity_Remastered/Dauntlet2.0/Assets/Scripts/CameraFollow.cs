using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform trackedObj;

    [SerializeField]
    float easeDistance = 3;

	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 campos = transform.position;
        Vector2 targetPos = trackedObj.position;

        if(Vector2.Distance(campos, targetPos) > easeDistance)
        {
            transform.position = Vector3.Lerp(transform.position, trackedObj.position + Vector3.forward * transform.position.z, Time.deltaTime );
        }
		
	}


}
