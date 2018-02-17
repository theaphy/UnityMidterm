using UnityEngine.AI;
using UnityEngine;


public class Interactable : MonoBehaviour {
	#region Variables
	public float radius = 3f;
	public Transform interactionTransform;
	Transform player;  

	#endregion

	#region Methods
	void Update()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		float distance = Vector3.Distance(player.position, interactionTransform.position);
		if (distance <= radius)
		{
			Interact();
		}
	}

	
	public virtual void Interact()
	{
		// This method is meant to be overwritten
	}
	#endregion
}