using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{

	public float jumpIterator = 4.5f;

	public void Shake()
	{
		float height = Mathf.PerlinNoise (jumpIterator, 0) * 5;
		height = height * height * 0.2f;

		//Degrees to shake the camera
		float shakeAmount = height; 

		//Period of each shake
		float shakePeriodOfTime = 0.25f;

		//How long it takes for the shaking to stop
		float dropOffTime = 1.25f;

		//No idea what this stuff does
		LTDescr shakeTween = LeanTween.rotateAroundLocal (gameObject, Vector3.right, shakeAmount, shakePeriodOfTime).setEase (LeanTweenType.easeShake).setLoopClamp().setRepeat (-1);

		LeanTween.value (gameObject, shakeAmount, 0, dropOffTime).setOnUpdate ((float val) => {
			shakeTween.setTo (Vector3.right * val);
		}).setEase (LeanTweenType.easeOutQuad);
	}

}
