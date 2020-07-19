using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_AI : MonoBehaviour
{
    float angle;
    float iq;

    private GameObject obstacle_1 { get; set; }
    // Start is called before the first frame update
    private void Create_Obstacle()
    {
        obstacle_1 = new GameObject
        {
            name = "Obstacle_1"
        };

        obstacle_1.AddComponent<obstacle_AI>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        iq += 1;

        if (iq >= 45)
        {
            iq = 0;
            Create_Obstacle();
        }

        angle = 0.8f;
        transform.Rotate(0, 0, angle);
    }
}
