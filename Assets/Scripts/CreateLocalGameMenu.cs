using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLocalGameMenu : MonoBehaviour
{
	public GameObject[] inputs;
	
	private int[] dropdownToInputMapping = {2,3,4,5,6,7,8};
	
	public void OnPlayerCountChanged(int playerCount)
	{
		int inputIndex = dropdownToInputMapping[playerCount];
		for(int i=0; i<inputs.Length; ++i)
		{
			if (i < inputIndex)
			{
				inputs[i].SetActive(true);
			}
			else
			{
				inputs[i].SetActive(false);
			}
		}
	}
}
