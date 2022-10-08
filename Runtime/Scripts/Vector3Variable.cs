using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        protected override Vector3 Clone(Vector3 value)
        {
            return value;
        }
    }
}