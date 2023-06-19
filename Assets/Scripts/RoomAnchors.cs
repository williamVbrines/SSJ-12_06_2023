using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAnchors : MonoBehaviour
{
    [SerializeField] private Vector3 roomAnchor;
    public Vector3 RoomAnchor { get { return roomAnchor; } }

    [SerializeField] private RoomAnchors northAnchor;
    public RoomAnchors NorthAnchor { get { return northAnchor; } }

    [SerializeField] private RoomAnchors eastAnchor;
    public RoomAnchors EastAnchor { get { return eastAnchor; } }

    [SerializeField] private RoomAnchors southAnchor;
    public RoomAnchors SouthAnchor { get { return southAnchor; } }

    [SerializeField] private RoomAnchors westAnchor;
    public RoomAnchors WestAnchor { get { return westAnchor; } }
}
