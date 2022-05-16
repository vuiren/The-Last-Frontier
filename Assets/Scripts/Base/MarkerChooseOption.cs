using System;
using UnityEngine;

namespace Base
{
    [Serializable]
    public class MarkerChooseOption
    {
        [SerializeField] private bool showMarker;

        [SerializeField] private bool showDistanceMarker;

        [SerializeField] private bool showPathIndicator;

        public MarkerChooseOption(bool showMarker = true, bool showDistanceMarker = false, bool showPathIndicator = false)
        {
            this.showMarker = showMarker;
            this.showDistanceMarker = showDistanceMarker;
            this.showPathIndicator = showPathIndicator;
        }

        public bool ShowPathIndicator => showPathIndicator;
        public bool ShowDistanceMarker => showDistanceMarker;
        public bool ShowMarker => showMarker;
    }
}