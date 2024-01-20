using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlateElementLayoutSnapshotNamespace
{
	public class PlateElementLayoutSnapshot
	{
		private int siblingIndexOfPlateSnapshot;
		private Transform layoutListOfPlateSnapshot;

		private PlateElementLayoutSnapshot(int siblingIndexOfPlateSnapshot, Transform layoutListOfPlateSnapshot)
		{
			this.siblingIndexOfPlateSnapshot = siblingIndexOfPlateSnapshot;
			this.layoutListOfPlateSnapshot = layoutListOfPlateSnapshot;
		}

		public static PlateElementLayoutSnapshot CaptureLayoutSnapshotOfPlate(Transform plateElement)
		{
			int siblingIndexOfPlate = plateElement.GetSiblingIndex();
			Transform layoutListOfPlate = plateElement.parent;

			PlateElementLayoutSnapshot newSnapshot = new PlateElementLayoutSnapshot(siblingIndexOfPlate, layoutListOfPlate);
			return newSnapshot;
		}

		public int GetCapturedSiblingIndex()
		{
			return siblingIndexOfPlateSnapshot;
		}

		public Transform GetCapturedLayoutListOfPlate()
		{
			return layoutListOfPlateSnapshot;
		}
	}
}