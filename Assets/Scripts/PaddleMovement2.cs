using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement2 : MonoBehaviour
{
   private bool isFlipped = false;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
		{
			//rotate object and set flipped to true
			if (!isFlipped)
			{
				isFlipped = true;
				StartCoroutine(RotatePaddle(-60, 0.1f));
				//transform.Rotate(0f,startRot+60f,0f);
			}
		}
		else
		{
			if (isFlipped)
			{
				isFlipped = false;
				StartCoroutine(RotatePaddle(+60, 0.1f));
				//transform.Rotate(0f,startRot-60f,0f);
			}
		}
    }
	
	IEnumerator RotatePaddle(float inAngle, float inTime)
	{
		var fromAngle = transform.localRotation;//current angle
		var desiredAngle = transform.localEulerAngles.y + inAngle;
		var desiredAngleQuaternion = Quaternion.Euler(transform.localEulerAngles.x, desiredAngle, transform.localEulerAngles.z);
		for (var t = 0f; t <= 1; t += Time.deltaTime/inTime)
		{
			transform.localRotation = Quaternion.Slerp(fromAngle, desiredAngleQuaternion, t);
			yield return null;
		}
	}
}