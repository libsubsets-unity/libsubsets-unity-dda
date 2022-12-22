using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace LibSubsets.SoA
{
    [CreateAssetMenu(menuName = "LibSubsets/SOArchitecture/Variable/Bool")]
    public class BoolVariable : BaseVariable<bool>
    {
        protected override bool Clone(bool value)
        {
            return value;
        }
    }
}