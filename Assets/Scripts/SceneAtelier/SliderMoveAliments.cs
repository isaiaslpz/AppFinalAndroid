using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMoveAliments : MonoBehaviour {

	public GameObject parentAliments;
	public Slider SliderDis;
	float maxVal = 0;

	public void MoveAliments()
	{
		Vector3 pos = parentAliments.transform.position;
		pos.x = -SliderDis.value;
		parentAliments.transform.position = pos;
		
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SetMaxValue();
	}

	void SetMaxValue()
	{
		float nb = MedicalAppManager.Instance().theScenario.aliments.Count;
		float decim = nb / 2 - 6;
		if(decim <= 0)
		{
			SliderDis.maxValue = 0;
			SliderDis.minValue = 0;
			SliderDis.value = 0;
		}
		else if(decim % 1 == 0)
		{
			maxVal = decim * 3;
			SliderDis.maxValue = maxVal;
		}
		else
		{
			maxVal = (decim + 0.5f) * 3;
			SliderDis.maxValue = maxVal;
		}
		
		
	}
	
}
