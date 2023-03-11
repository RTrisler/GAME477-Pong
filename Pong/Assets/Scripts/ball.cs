using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Vector2 dir;
    public int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        //using polar coordinates, the direction of the ball is randomly determined in the beginning.
        float x = Random.value;
        if(x>0.5){
            float randir = Mathf.PI*Random.Range(0.5f,2.5f);
            dir.x = Mathf.Cos(randir);
            dir.y = Mathf.Sin(randir);
        }
        else{
            float randir = Mathf.PI*Random.Range(3.5f,5.5f);
            dir.x = Mathf.Cos(randir);
            dir.y = Mathf.Sin(randir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }

    //simple collision. This will bounce between the two paddles for now.
    void OnCollisionEnter2D(Collision2D c){
        dir.x *=-1;
        dir.y *=-1;
    }
}
