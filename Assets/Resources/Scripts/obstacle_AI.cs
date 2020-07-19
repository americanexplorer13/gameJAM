using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_AI : MonoBehaviour
{
    public Transform trans;
    private SpriteRenderer rend;
    //private PolygonCollider2D coll;
    
    public Vector3 localScale;
    float sc = 0.2f;

    void Start()
    {
        //START -->
        // Transform block -->
        trans = gameObject.GetComponent<Transform>();
        trans.transform.position = new Vector3(0, 0, 1);
        trans.transform.localScale = new Vector2(13, 13);
        // Sprite Renderer block -->
        rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>($"Sprites/obstacle_{2}");
        rend.sortingOrder = 0;
        // PolygonCollider2D block -->
        gameObject.AddComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        if (transform.localScale.y <= 1.1f)
        {
            Destroy(gameObject);
        }

        transform.localScale -= new Vector3(sc, sc, 0);
    }
}
