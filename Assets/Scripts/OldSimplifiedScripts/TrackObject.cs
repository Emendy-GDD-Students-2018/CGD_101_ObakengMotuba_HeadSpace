using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour {
    public Transform target;
    GameObject charecter;
    public float speed = 4.0f;
    Vector2 find;

    private void Update()
    {
        find = (target.position - transform.position).normalized;
        transform.Translate(find * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider gamespace)
    {
        SpotObject();
    }

    void SpotObject()
    {

    }



}
