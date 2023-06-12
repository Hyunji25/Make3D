using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    private Camera camera;

    public Node Target;

    private float Speed;

    Vector3 LeftCheck;
    Vector3 RightCheck;

    [Range(0.0f, 180.0f)]
    public float Angle;

    private bool move;

    private bool View;

    private Vector3 offset;

    private void Awake()
    {
        camera = Camera.main;

        SphereCollider coll = GetComponent<SphereCollider>();
        coll.radius = 0.05f;
        coll.isTrigger = true;

        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;

        Target = GameObject.Find("ParentObject").transform.GetChild(0).GetComponent<Node>();
    }

    private void Start()
    {
        Speed = 5.0f;

        float x = 2.5f;
        float z = 3.5f;

        LeftCheck = transform.position + (new Vector3(-x, 0.0f, z));
        RightCheck = transform.position + (new Vector3(x, 0.0f, z));

        Angle = 45.0f;

        move = false;
        View = false;

        offset = new Vector3(0.0f, 10.0f, 10.0f);
    }

    private void Update()
    {
        View = Input.GetKey(KeyCode.Tab) ? true : false;

        if (View)
        {
            offset = new Vector3(0.0f, 5.0f, -3.0f);
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 100.0f, 0.012f);
        }
        else
        {
            offset = new Vector3(0.0f, 10.0f, -10.0f);
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60.0f, 0.012f);
        }

        camera.transform.position = Vector3.Lerp(
            camera.transform.position,
            transform.position + offset, 
            0.016f);
        
        camera.transform.LookAt(transform.position);


        if (Target)
        {
            if (move)
            {
                Vector3 Direction = (Target.transform.position - transform.position).normalized;
                transform.position += Direction * Speed * Time.deltaTime;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.LookRotation(Vector3.back),
                    Time.deltaTime);

                transform.rotation = Quaternion.Lerp(
                    camera.transform.rotation,
                    Quaternion.LookRotation(Vector3.forward, Vector3.back),
                    Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        //Debug.DrawRay(transform.position, LeftCheck * 5.0f, Color.red);

        Debug.DrawRay(transform.position,
            new Vector3(
                Mathf.Sin(-Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(-Angle * Mathf.Deg2Rad)) * 2.5f,
            Color.white);

        if (Physics.Raycast(transform.position, LeftCheck, out hit, 5.0f))
        {

        }

        //Debug.DrawRay(transform.position, RightCheck * 5.0f, Color.red);

        Debug.DrawRay(transform.position,
            new Vector3(
                Mathf.Sin(Angle * Mathf.Deg2Rad), 0.0f, Mathf.Cos(Angle * Mathf.Deg2Rad)) * 2.5f,
            Color.green);

        if (Physics.Raycast(transform.position, RightCheck, out hit, 5.0f))
        {

        }

        for (float f = -Angle; f <= Angle; f += 5.0f)
        {
            Debug.DrawRay(transform.position,
            new Vector3(
                Mathf.Sin(f * Mathf.Deg2Rad), 0.0f, Mathf.Cos(f * Mathf.Deg2Rad)) * 2.5f,
            Color.red);
        }
    }

    void function()
    {
        if (move)
            return;

        move = true;
        StartCoroutine(SetMove());
    }

    IEnumerator SetMove()
    {
        float time = 0.0f;

        while (time < 1.0f)
        {
            

            time += Time.deltaTime;

            yield return null;
        }

        move = false;
    }

    private void OnTriggerEnter(Collider other) // 트리거에 체크되어 있으면 이거, 아니면 OnCollisionEnter
    {
        if (Target.transform.name == other.transform.name)
            Target = Target.Next;
    }
}
