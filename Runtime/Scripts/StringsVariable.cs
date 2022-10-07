using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace PlayGem.JawRed.Core.Variables
{
    [CreateAssetMenu]
    public class StringsVariable : BaseVariable<List<string>>
    {
        protected override void Initialize()
        {
            Value = InitialValue.ToList();
        }
    }
}