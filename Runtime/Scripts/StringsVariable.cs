using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringsVariable : BaseVariable<List<string>>
    {
        protected override List<string> Clone(List<string> value)
        {
            return value.ToList();
        }
    }
}