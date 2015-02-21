using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public float smoothTime = 0.3f;
	public float maxSize;
	public float minSize;

	private float duration = 1.0f;
	private float elapsed = 0;
	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 16.0f / 9.0f;
		
		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;
		
		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;
		
		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();
		
		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;
			
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			
			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;
			
			Rect rect = camera.rect;
			
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			
			camera.rect = rect;
		}
	}

	void Update () 
	{
		float posX = target.position.x;
		float posY = target.position.y;
		float posZ = -1;

		Vector3 newPos = new Vector3(posX, posY, posZ);
		Vector3 origin = new Vector3(0f, 0f, -1);
		transform.position = Vector3.SmoothDamp (transform.position, newPos, ref velocity, smoothTime);

		if (Input.GetKey(KeyCode.Tab)) 
		{
			if (elapsed <= 1.0f) 
			{
				elapsed += Time.deltaTime * duration;
				Camera.main.orthographicSize = Mathf.Lerp(minSize, maxSize, elapsed);
			}
		}
		else
		{
			if (elapsed >= 0f) 
			{
				elapsed -= Time.deltaTime * duration;
				Camera.main.orthographicSize = Mathf.Lerp(minSize, maxSize, elapsed);
			}
		}
	}
}