using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GroundTriggers : MonoBehaviour, IPointerClickHandler {

	public PlayerController player;

	// Will work for clicks and Cardboard trigger presses
	public void OnPointerClick(PointerEventData eventData)
	{
		player.SetMoveTowardsPoint (eventData.pointerCurrentRaycast.worldPosition);
	}

}