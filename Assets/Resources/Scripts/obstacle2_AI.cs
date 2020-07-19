using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle2_AI : MonoBehaviour
{
    public Transform trans;
    private SpriteRenderer rend;
    private PolygonCollider2D coll;

    public Vector3 localScale;
    float sc = 0.2f;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        //START -->
        // Transform block -->
        trans = gameObject.GetComponent<Transform>();
        trans.transform.position = new Vector3(0, 0, 1);
        trans.transform.localScale = new Vector2(14, 14);
        // Sprite Renderer block -->
        rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = Resources.Load<Sprite>("Sprites/obstacle_1");
        rend.sortingOrder = 0;
        // PolygonCollider2D block -->
        gameObject.AddComponent<PolygonCollider2D>();
        //<-- END
    }

    // Update is called once per frame
    void Update()
    {
        angle += 0.2f;

        if (transform.localScale.y <= 1.1f)
        {
            Destroy(gameObject);
        }

        transform.Rotate(0, 0, angle);
        transform.localScale -= new Vector3(sc, sc, 0);
    }
}
