using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/Float")]
    public class FloatVariable : BaseVariable<float>
    {
        protected override float Clone(float value)
        {
            return value;
        }
    }
}