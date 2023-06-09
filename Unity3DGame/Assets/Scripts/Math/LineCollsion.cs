using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    public Vector3 StartPoint;
    public Vector3 EndPoint;
}

public class LineCollsion : MonoBehaviour
{
    public List<Line> LineList = new List<Line>();

    [SerializeField] private float Width;
    [SerializeField] private float Height;

    void Start()
    {
        Vector3 OldPoint = new Vector3(0.0f, 0.0f, 0.0f);

        for (int i =0;i<20; ++i)
        {
            Line line = new Line();

            line.StartPoint = OldPoint;

            float fY = 0.0f;

            while (true)
            {
                fY = Random.Range(-5.0f, 5.0f);

                if (fY != 0.0f)
                    break;
            }
            OldPoint = new Vector3(
                OldPoint.x + Random.Range(1.0f, 5.0f),
                OldPoint.y + fY,
                0.0f);

            line.EndPoint = OldPoint;

            LineList.Add(line);
        }

        Width = 0.0f;
        Height = 0.0f;
    }

    void Update()
    {
        foreach (Line element in LineList)
        {
            Debug.DrawLine(element.StartPoint, element.EndPoint, Color.green);

            Width = element.EndPoint.x - element.StartPoint.x;
            Height = element.EndPoint.y - element.StartPoint.y;

        }

        foreach (Line element in LineList)
        {
            if (element.StartPoint.x <= transform.position.x && transform.position.x < element.EndPoint.x)
            {
                Width = element.EndPoint.x - element.StartPoint.x;
                Height = element.EndPoint.y - element.StartPoint.y;

                Debug.DrawLine(element.StartPoint, element.EndPoint, Color.red);

                transform.position = new Vector3(
                    transform.position.x,
                    Height / Width * (transform.position.x),
                    0.0f);
            }
        }
    }
}

// y = (StartPoint.y - EndPoint.y) / (StartPoint.x - EndPoint.x) * x

/*
 Vector3 Movement = new Vector3(
            hor + Mathf.Cos(Angle * Mathf.Deg2Rad) * 5.0f, // (hor+1)5
            ver + Mathf.Cos(Angle * Mathf.Deg2Rad) * 5.0f,
            0.0f) * 5.0f * Time.deltaTime;
 */