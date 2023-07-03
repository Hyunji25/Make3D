using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    private Vector3 direction;
    private Transform target;
    private float distance;

    public LayerMask mask;

    private const string path = "Legacy Shaders/Transparent/Specular";

    private bool Check;

    private void Awake()
    {
        //camera = GetComponent<Camera>();
        camera = Camera.main;

        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        direction = (target.position - transform.position).normalized;

        distance = Vector3.Distance(target.position, transform.position);

        Check = false;
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + direction * distance, Color.green);
        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            if (hit.transform != null)
            {
                if (Check == false)
                {
                    Check = true;
                    Renderer renderer = hit.transform.GetComponent<Renderer>();

                    if (renderer != null)
                        StartCoroutine(SetColor(renderer));
                }
            }
        }
    }

    IEnumerator SetColor(Renderer renderer)
    {
        // ** Color�� ������ ������ Shader�� ����
        Material material = new Material(Shader.Find(path));

        // ** ����� Shader�� Color���� �޾ƿ�
        Color color = renderer.material.color;

        // ** color.a�� 0.5f���� ū ��쿡�� �ݺ�
        while (0.5f < color.a)
        {
            yield return null;

            // ** Alpha(1) -= Time.deltaTime
            color.a -= Time.deltaTime;

            renderer.material.color = color;
        }
    }
}
