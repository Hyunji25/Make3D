using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterController : MonoBehaviour
{
    public List<GameObject> PointList;

    void Start()
    {
        // 360���� 5����ŭ -> 360 / 5 = 72
        // 360���� n����ŭ -> 360 / n
        for (int i = 0;i < 72;++i)
        {
            GameObject obj = new GameObject("point");

            obj.AddComponent<MyGizmo>();

            obj.transform.position = new Vector3(
                Mathf.Sin((i * 5.0f) * Mathf.Deg2Rad),
                Mathf.Cos((i * 5.0f) * Mathf.Deg2Rad),
                0.0f) * 5.0f;

            PointList.Add(obj);
        }
    }
}

// 1���� = 180 / PI(����)
// 1�� = PI / 180