using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_AI : MonoBehaviour
{
    public Transform trans;
    private SpriteRenderer rend;
    private PolygonCollider2D coll;
    
    public Vector3 localScale;
    float qx = 0.1f;
    float qy = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        int[] authors = { 0, 30, 60, 90, 120, 160, 180};
        int index = Random.Range(0, authors.Length);
        //START -->
        // Transform block -->
        trans = gameObject.GetComponent<Transform>();
        trans.transform.position = new Vector3(0, 0, 1);
        trans.transform.localScale = new Vector2(13, 13);
        trans.transform.Rotate(0, 0, authors[index]);
        // Sprite Renderer block -->
        rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>("Sprites/obstacle_1");
        rend.sortingOrder = 0;
        // Box Collider 2D block -->
        coll = gameObject.AddComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.localScale.y <= 1.0f){
            Destroy(gameObject);
        }

        transform.localScale -= new Vector3(qx, qy, 0);
    }
}
