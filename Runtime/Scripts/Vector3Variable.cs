using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/Vector3Variable")]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        protected override Vector3 Clone(Vector3 value)
        {
            return new Vector3(value.x, value.y, value.z);
        }
    }
}