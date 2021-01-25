using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MarkerChooseOption
{
	[SerializeField]
	bool showMarker;

	[SerializeField]
	bool showDistanceMarker;

	[SerializeField]
	bool showPathIndicator;

	public MarkerChooseOption(bool showMarker = true, bool showDistanceMarker = false, bool showPathIndicator = false)
	{
		this.showMarker = showMarker;
		this.showDistanceMarker = showDistanceMarker;
		this.showPathIndicator = showPathIndicator;
	}

	public bool ShowPathIndicator { get => showPathIndicator; }
	public bool ShowDistanceMarker { get => showDistanceMarker; }
	public bool ShowMarker { get => showMarker; }
}

public class ChoosingController : MonoBehaviour
{
	[SerializeField]
	GameObject marker;

	[SerializeField]
	GameObject attackDistanceMarker;

	[SerializeField]
	GameObject pathIndicator;

	[SerializeField]
	MarkerChooseOption chooseLastOption = new MarkerChooseOption(true, true, true);

	[SerializeField]
	MarkerChooseOption chooseOption = new MarkerChooseOption();

	[SerializeField]
	MarkerChooseOption stopChooseOption = new MarkerChooseOption(false);

	[Button]
	public void ChooseOption()
	{
		SetMarkersActive(chooseOption);
	}

	[Button]
	public void ChooseLastOption()
	{
		SetMarkersActive(chooseLastOption);
	}

	[Button]
	public void StopChoosingOption()
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
