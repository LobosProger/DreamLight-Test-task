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

		public PlateElementData(string nameOfPlate, int numberOfPlate)
		{
			this.nameOfPlate = nameOfPlate;
			this.numberOfPlate = numberOfPlate;
		}

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
