using UnityEngine;
using System.Collections;

public class BucketController : MonoBehaviour {

    private float maxWidth;
    public Camera cam;
    

	// Use this for initialization
	void Start () {
	    if(cam == null)
        {
            cam = Camera.main;
        }

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float bucketWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - bucketWidth;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rawPos = new Vector3();
        rawPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = new Vector3(rawPos.x, 0.0f, 0.0f);

        float targetWidth = Mathf.Clamp(targetPos.x, -maxWidth, maxWidth);
        targetPos = new Vector3(targetWidth, targetPos.y, targetPos.z);

        GetComponent<Rigidbody2D>().MovePosition(targetPos);

    }
}

