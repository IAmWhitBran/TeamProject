﻿using UnityEngine;
using System.Collections;

/*
 * Changed Camera to move relative to the player.
 * 
 * The other option is relocating the camera to the
 * top centre of the next room we enter.
 *
 * The latter option may suit handheld devices better
 * due to screen size.
 */
public class MoveCamera : MonoBehaviour {

    private GameObject m_Camera, m_DLight;
	private Vector3	newCameraPosition;

    // Use this for initialization
    void Start() {
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera");
        m_DLight = GameObject.FindGameObjectWithTag("DLight");
        newCameraPosition = m_Camera.transform.position;
    }

    // Update is called once per frame
    void Update() {
        newCameraPosition.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        newCameraPosition.z = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        m_Camera.transform.position = newCameraPosition;
        m_DLight.transform.position = newCameraPosition;
    }

    //void OnTriggerEnter()
    //{
    //    mCamera = GameObject.FindGameObjectWithTag ("MainCamera");
    //    newCameraPosition = this.transform.position;
    //    newCameraPosition.y += 20;
    //    mCamera.transform.position = newCameraPosition;
    //}
}
