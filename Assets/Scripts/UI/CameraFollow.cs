using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	#region Singleton
	public static CameraFollow instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<CameraFollow>();
			}
			return _instance;
		}
	}
	static CameraFollow _instance;

	void Awake()
	{
		_instance = this;
	}
	#endregion

	#region Variables
	Transform target;
	public int offset = -10;
	float newOffset = 5;
	Camera cam;
	#endregion
	
	#region Methods
	void Start () {
		cam = gameObject.GetComponent<Camera>();
	}
	
	void LateUpdate () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3(target.position.x, target.position.y, offset);
		if (newOffset != 5) {
			ChangeOffset();
		}
		
	}
	public void GetNewOffset(float offset) {
		newOffset = offset;
	}

	public void ChangeOffset() {
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newOffset, Time.deltaTime);
	}
	#endregion
}
