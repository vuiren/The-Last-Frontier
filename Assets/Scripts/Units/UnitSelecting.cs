using Base;
using UnityEngine;

namespace Units
{
	public class UnitSelecting : MonoBehaviour
	{
		[SerializeField] private GameObject marker, attackDistanceMarker, pathIndicator;
	
		[SerializeField] private MarkerChooseOption chooseLastOption = new(true, true, true);

		[SerializeField] private MarkerChooseOption chooseOption;

		[SerializeField] private MarkerChooseOption stopChooseOption = new(false);

		public void Select()
		{
			SetMarkersActive(chooseOption);
		}

		public void ChooseLastOption()
		{
			SetMarkersActive(chooseLastOption);
		}

		public void Deselect()
		{
			SetMarkersActive(stopChooseOption);
		}

		private void SetMarkersActive(MarkerChooseOption chooseOption)
		{
			marker.SetActive(chooseOption.ShowMarker);
			attackDistanceMarker.SetActive(chooseOption.ShowDistanceMarker);
			pathIndicator.SetActive(chooseOption.ShowPathIndicator);
		}
	}
}