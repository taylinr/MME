﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageHandler : MonoBehaviour
{
    public ARTrackedImageManager _trackedImageManager;
    public GameObject _content;
    private void Start()
    {

        _content.SetActive(false);

        if(!_trackedImageManager)
        {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        }
    }
    void OnEnable() => _trackedImageManager.trackedImagesChanged += OnChanged;
    void OnDisable() => _trackedImageManager.trackedImagesChanged -= OnChanged;
    
    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
    foreach (var trackedImage in eventArgs.added)
        {

        _content.SetActive(true);
        _content.transform.parent = trackedImage.transform;

        var minLocalScalar = Mathf.Min(trackedImage.size.x, trackedImage.size.y) / 2;
        trackedImage.transform.localScale = new Vector3(minLocalScalar,
        minLocalScalar,
        minLocalScalar);
        // _content.transform.localScale = Vector3.one;
        }
    }
}