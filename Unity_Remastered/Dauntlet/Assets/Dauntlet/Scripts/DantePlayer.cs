using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DantePlayer : MonoBehaviour {

    Animator dAnimator;

	// Use this for initialization
	void Start () {
        dAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float inputHorizon = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        dAnimator.SetFloat("Horizontal", inputHorizon);
        dAnimator.SetFloat("Vertical", inputVertical);
        
        if(inputHorizon > 0.5f)
        {
            transform.localScale = new Vector3(-1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1);
        }

        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(inputHorizon, inputVertical),ForceMode2D.Force);

        Debug.Log("Horizon" + inputHorizon);
        Debug.Log("Vertical" + inputVertical);
    }
}
