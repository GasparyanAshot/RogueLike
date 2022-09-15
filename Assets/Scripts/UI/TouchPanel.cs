using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour ,IDragHandler ,IPointerDownHandler ,IPointerUpHandler{

	public bool IsTouched=false;
	public Vector2 TouchedPosition;
	public RectTransform ThisRectTransform;
	public Joystick joystick;

	public virtual void OnDrag(PointerEventData ped){
		joystick.OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		IsTouched = false;
		joystick.SetStartPositionBack ();
	}

	public virtual void OnPointerDown(PointerEventData ped){
			IsTouched = true;
			RectTransformUtility.ScreenPointToLocalPointInRectangle (ThisRectTransform, ped.position, ped.enterEventCamera, out TouchedPosition);
			joystick.SetNewStartPosition (TouchedPosition);
	}
		
}
