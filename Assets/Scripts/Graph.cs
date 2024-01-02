using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab; //cube prefab pointer(?)
    [SerializeField, Range(10, 100)] int resolution = 10; //resolution
    Transform[] points;

    void Awake () {
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution]; //array to store the coordinates of each cube instance

        for(int i = 0; i < points.Length; i++){
            //code to render first instance of cube prefab
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = ((i + 0.5f) * step) - 1f;
            // position.y = position.x * position.x * position.x; //since we are using update
                point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
        // point = Instantiate(pointPrefab);
        // point.localPosition = Vector3.right * 2f;
	}
    
    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        for(int i = 0; i < points.Length; i++){
            Transform point = points[i];
            Vector3 position = point.localPosition;
            // position.y = position.x * position.x * position.x;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
