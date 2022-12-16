using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Variable/Vector3")]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        protected override Vector3 Clone(Vector3 value)
        {
            return value;
        }
    }
}