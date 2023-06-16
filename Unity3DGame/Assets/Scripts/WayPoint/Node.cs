using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
public class Node// : MonoBehaviour
{
    public Vector3 Position;
    public Node Next;
    public float Cost;

    public Node()
    {
        Next = null;
        Cost = 0.0f;
    }

    public Node(Vector3 _position)
    {
        Position = _position;
        Next = null;
        Cost = 0.0f;
    }

    public Node(Node _node, float _cost)
    {
        Position = Vector3.zero;
        Next = _node;
        Cost = _cost;
    }

    public Node(Vector3 _position, Node _node, float _cost)
    {
        Position = _position;
        Next = _node;
        Cost = _cost;
    }

    //private void Start()
    //{
    //    transform.tag = "node";

    //    spherecollider coll = getcomponent<spherecollider>();
    //    coll.radius = 0.2f;
    //    coll.istrigger = true;
    //}
}