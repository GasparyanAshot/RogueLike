using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour ,IDragHandler ,IPointerDownHandler ,IPointerUpHandler {

	private Image BgImage;
	private Image JoystickImage;
	public Vector2 InputVector;
	private Vector2 StartPos;
	public Canvas canvas;

	private void Start(){
		BgImage = GetComponent<Image> ();
		JoystickImage = transform.GetChild (0).GetComponent<Image> ();
		StartPos = BgImage.rectTransform.anchoredPosition;
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (BgImage.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / BgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / BgImage.rectTransform.sizeDelta.y);

			InputVector = new Vector2 (pos.x * 2, pos.y * 2);
			InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

			JoystickImage.rectTransform.anchoredPosition=new Vector3(InputVector.x*(BgImage.rectTransform.sizeDelta.x/3),InputVector.y*(BgImage.rectTransform.sizeDelta.y/3),0);


		}
	}

	public virtual void OnPointerUp(PointerEventData ped){
		InputVector = Vector2.zero;
		JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}

	public void SetNewStartPosition(Vector2 NewPos){
		BgImage.rectTransform.anchoredPosition= NewPos+StartPos;
	}

	public void SetStartPositionBack(){
		BgImage.rectTransform.anchoredPosition = StartPos;
		JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
		InputVector = Vector2.zero;
	}
}
