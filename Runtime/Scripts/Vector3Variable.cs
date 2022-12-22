using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/Vector3")]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        protected override Vector3 Clone(Vector3 value)
        {
            return value;
        }
    }
}