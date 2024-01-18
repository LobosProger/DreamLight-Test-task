using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlateElementNamespace
{
	[System.Serializable]
	public class PlateElementData
	{
		[SerializeField] private string nameOfPlate;
		[SerializeField] private int numberOfPlate;

		public string GetNameOfPlate()
		{
			return nameOfPlate;
		}

		public int GetNumberOfPlate()
		{
			return numberOfPlate;
		}
	}
}
