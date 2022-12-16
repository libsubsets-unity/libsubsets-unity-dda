using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Subsets.Message2.Runtime
{
    [CreateAssetMenu(menuName = "Message2/Variable/Long")]
    public class LongVariable : BaseVariable<long>
    {
        protected override long Clone(long value)
        {
            return value;
        }
    }
}