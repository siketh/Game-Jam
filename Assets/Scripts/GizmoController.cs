using UnityEngine;
using System.Collections;

public class GizmoController : MonoBehaviour {

	private PlayerController playerController;
	void Start() {
		playerController = transform.parent.GetComponent<PlayerController> ();
	}

	void OnDrawGizmos() {
		if (playerController == null)
						return;
		int total = playerController.adjacentAgents.Count;
		if (total == 0)
			Gizmos.color = Color.green;
		else if (total < 3)
			Gizmos.color = Color.yellow;
		else
			Gizmos.color = Color.red;
		Vector3 rot = transform.rotation.eulerAngles;
		rot.z = rot.z + 45;
		Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(rot), transform.lossyScale);
		Gizmos.matrix = rotationMatrix;
		Gizmos.DrawWireSphere (Vector3.zero, .75f);
	}
}
