
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace1;
    public GameObject objectToPlace2;
    public GameObject placementIndicator;
    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    int objectsPlaced;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();   
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (objectsPlaced < 1)
            {
                PlaceObject1();
                objectsPlaced++;
            }
            else if (objectsPlaced < 4)
            {
                PlaceObject2();
                objectsPlaced++;
            }
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            //var cameraForward = Camera.current.transform.forward;
            //var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            //placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(true);
        }
    }

    void PlaceObject1()
    {
        Instantiate(objectToPlace1, placementPose.position, placementPose.rotation);
    }

    void PlaceObject2()
    {
        Instantiate(objectToPlace2, placementPose.position, placementPose.rotation);
    }
}
