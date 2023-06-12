using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float dis;

    private Vector3 temp;
    private Vector3 dest;

    private int check;
    private bool move;

    private void Start()
    {
        dis = 0.0f;

        temp = new Vector3(0.0f, 0.0f, 0.0f);
        dest = new Vector3(100.0f, 0.0f, 0.0f);
        check = 0;
        move = false;
    }

    void Update()
    {
        //transform.eulerAngles = new Vector3(0.0f, Angle, 0.0f);

        Quaternion rotation = transform.rotation; // 플레이어값 받아와서

        // ** rotation 각의 변경

        //transform.rotation = Quaternion.Lerp(transform.rotation, ) // (시작점, 끝점, 비율)

        transform.rotation = rotation; // 변경된 값을 플레이어값으로 세팅

        if (Input.GetMouseButtonDown(0))
        {
            function();
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

        check = (check == 0) ? 1 : 0;

        while(time < 1.0f)
        {
            if (check == 0)
            {
                transform.position = Vector3.Lerp(
                   dest, // 시작점
                   temp, // 끝점
                   time); // 비율, 거리 
            }
            else
            {
                transform.position = Vector3.Lerp(
                    temp, // 시작점
                    dest, // 끝점
                    time); // 비율, 거리 
            }

            time += Time.deltaTime;

            yield return null;
        }
         
        move = false;
    }
}


// Rad2Deg이랑 Deg2Rad 차이
// 동기 비동기(코루틴)