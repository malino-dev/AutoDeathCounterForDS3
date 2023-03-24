using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDeathCounterForDS3.OffsetDataNS;

public interface IOffsetData
{
    int BaseA { get; }
    int BaseB { get; }

    PointerInfo DeathNum { get; }
    PointerInfo Hp { get; }
}
