using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Subsets.Dda
{
    [CreateAssetMenu(menuName = "Subsets.Dda/Variable/BoolVariable")]
    public class BoolVariable : BaseVariable<bool>
    {
        protected override bool DuplicateValue(bool value)
        {
            return value;
        }
    }
}