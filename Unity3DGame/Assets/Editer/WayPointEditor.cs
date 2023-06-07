using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;





public class WayPointEditor : Editor
{
    private void OnSceneGUI()
    {
        //SerializedObject Object = 
        //GUILayout.

        if (GUILayout.Button("zzzzz"))
        {

        }

        WayPoint Target = (WayPoint)target;
        Debug.Log(Target.number);
    }
}
