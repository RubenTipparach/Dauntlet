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

    [SerializeField]
    Animator animator;

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

            if(horiz > 0)
            {
                animator.transform.localScale = new Vector3(-1, 1, 1);
                horiz = -horiz;
            }
            else
            {
                animator.transform.localScale = new Vector3(1, 1, 1);
            }

            // s
            if (horiz == 0 && vert < 0)
            {
                animator.SetInteger("dir", 0);
            }

            //sw
            if (horiz < 0 && vert < 0)
            {
                animator.SetInteger("dir", 1);
            }

            // west
            if (horiz < 0 && vert == 0)
            {
                animator.SetInteger("dir", 2);
            }

            //nw
            if (horiz < 0 && vert > 0)
            {
                animator.SetInteger("dir", 3);
            }

            //n
            if (horiz == 0 && vert > 0)
            {
                animator.SetInteger("dir", 4);
            }
        }

    }

}
