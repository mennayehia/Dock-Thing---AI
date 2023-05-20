using System.Collections;
using System.Collections.Generic;
using BBUnity.Actions;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Unity.VisualScripting;

[Action("OurPath/Test2")]
public class Test2 : GOAction
{
    //[InParam("player")]
    //public Transform player;
    public float duration = 2f; // duration of the color change in seconds

    private float startTime;
    public override void OnStart()
    {
        Debug.Log("Start");
        base.OnStart();

        startTime = Time.time;


        this.gameObject.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
      

    }
    public override void OnEnd()
    {
        base.OnEnd();

    }

    public override TaskStatus OnUpdate()
    {
        float t = (Time.time - startTime) / duration;

        this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.magenta, Color.blue, t);

        return base.OnUpdate();


    }
}
