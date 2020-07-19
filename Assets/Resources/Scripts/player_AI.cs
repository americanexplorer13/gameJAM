using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player_AI : MonoBehaviour
{
    float angle = 0f;
    float radius = 1.05f;
    float speed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log('d');
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(gameObject);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // angle += Time.deltaTime; // меняется плавно значение угла
        if (Input.GetKey(KeyCode.A))
        {
            angle += 0.2f; // меняется плавно значение угла
            transform.Rotate(0, 0, 10);
        }

        if (Input.GetKey(KeyCode.D))
        {
            angle -= 0.2f; // меняется плавно значение угла
            transform.Rotate(0, 0, 10);
        }
        
        var x = Mathf.Cos(angle * speed) * radius;
        var y = Mathf.Sin(angle * speed) * radius;
        transform.position = new Vector2(x, y);
    }
}
