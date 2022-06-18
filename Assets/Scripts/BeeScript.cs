using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeeScript : MonoBehaviour
{
    public float angle = 0; 
    public float radius  = 2.5f;
    public float speed = 1f;
    public GameObject button;
    void Update()
    {
        angle += Time.deltaTime;
        var x = Mathf.Cos (angle * speed) * radius;
        var y = Mathf.Sin (angle * speed) * radius;
        var transform1 = transform;
        transform1.position = new Vector2(x, y);
        transform1.eulerAngles = Vector3.forward * (angle * 100);
    }
    public void OnTriggerEnter2D(Collider2D petal)
    {
        Debug.Log("trigger");
        button.GetComponent<ButtonTapScript>()._isTriggerEntered = true;
    }
    public void OnTriggerExit2D(Collider2D petal)
    {
        button.GetComponent<ButtonTapScript>()._isTriggerEntered = false;
    }
}
