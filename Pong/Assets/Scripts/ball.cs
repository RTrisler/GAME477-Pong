using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public ScoreManager scoreManager;

    public Vector2 dir;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //using polar coordinates, the direction of the ball is randomly determined in the beginning.
        gameObject.transform.position = new Vector3(0,0,1);
        float x = Random.value;
        if(x>0.5){
            float randir = Mathf.PI*Random.Range(0.7f,1.3f);
            dir.x = Mathf.Cos(randir);
            dir.y = Mathf.Sin(randir);
        }
        else{
            float randir = Mathf.PI*Random.Range(1.7f,2.3f);
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
        // when the ball hits a paddle, it will go back through the middle at a random point to bounce back.
        if(c.gameObject.CompareTag("paddleLeft")){
            float rany = Random.Range(-2.5f,2.5f);
            float ranx = Random.Range(0f,0.5f);
            float disx = (ranx-transform.position.x)/2;
            float disy = (rany-transform.position.y)/2;
            dir = new Vector2(disx,disy);
        }
        else if(c.gameObject.CompareTag("paddleRight")){
            float rany = Random.Range(-2.5f,2.5f);
            float ranx = Random.Range(-0.5f,0);
            float disx = (ranx-transform.position.x)/2;
            float disy = (rany-transform.position.y)/2;
            dir = new Vector2(disx,disy);
        }
        // if the ball hits a boundary collision it will alert who won the round and reset the ball in the middle of the arena
        else if(c.gameObject.CompareTag("rightCollisions")){
            scoreManager.Player1Goal();
            Start();
        }
        else if(c.gameObject.CompareTag("leftCollisions")){
            scoreManager.Player2Goal();
            Start();
        }
        
     }
}