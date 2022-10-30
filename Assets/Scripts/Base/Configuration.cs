using UnityEngine;

namespace Base
{
    
    [CreateAssetMenu(fileName = "New Configuration", menuName = "Add Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public UnitNpcInfo[] NpcInfoUnitTypes;
    }
}