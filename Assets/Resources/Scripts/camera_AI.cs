﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_AI : MonoBehaviour
{
    int[] angle_list = { 0, 30, 60, 90, 120, 160, 180 };
    public Camera m_OrthographicCamera;
    public int frequency = 20;
    const float angle = 0.8f;
    int timer_mil = 0;
    int timer = 0;
    int iq = 0;
    int mem;

    private GameObject obstacle_1 { get; set; }

    private void Create_Obstacle()
    {
        int angle_index = Random.Range(0, angle_list.Length);

        if (mem == angle_index && angle_index >= 3)
        {
            angle_index -= Random.Range(0, 4);
        }
        else if (mem == angle_index && angle_index <= 3)
        {
            angle_index += Random.Range(1, 3);
        }
        Debug.Log(angle_index);
        mem = angle_index;
        obstacle_1 = new GameObject
        {
            name = "Obstacle_1"
        };

        if (4 % Random.Range(1, 10) == 0)
        {
            obstacle_1.AddComponent<obstacle2_AI>();
        }

        else
        {
            obstacle_1.AddComponent<obstacle_AI>();
        }

        obstacle_1.transform.Rotate(0, 0, angle_list[angle_index]);

    }

    void Start()
    {
        Application.targetFrameRate = 60;
        m_OrthographicCamera = this.GetComponent<Camera>();
        GameObject.Find("Timer").GetComponent<UnityEngine.UI.Text>().text = "00:01";
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
    {
        timer_mil += 1;

        if (timer_mil == 100)
        {
            timer += 1;
            timer_mil = 0;
        }

        GameObject.Find("Timer").GetComponent<UnityEngine.UI.Text>().text = $"{timer:00}:{timer_mil:00}";
        m_OrthographicCamera.orthographicSize = Mathf.Abs(0.7f * Mathf.Sin(frequency * Time.time) - 8f);

        iq += 1;
        if (iq >= 45)
        {
            iq = 0;
            Create_Obstacle();
        }

        transform.Rotate(0, 0, angle);
    }
}
