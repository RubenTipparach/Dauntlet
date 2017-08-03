using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DantePlayer : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 10;

    Vector3 position;

    Vector3 lastPosition;

    [SerializeField]
    LayerMask wallLayers;


    // Use this for initialization
    void Start () {
        position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate()
    {
        //lastPosition = transform.position;

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (horiz != 0 || vert != 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(horiz, vert) * moveSpeed, ForceMode2D.Impulse);
        }
    }

}
