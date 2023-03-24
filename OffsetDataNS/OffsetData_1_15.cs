using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDeathCounterForDS3.OffsetDataNS;

public class OffsetData_1_15 : IOffsetData
{
    public int BaseA => 0x4740178;

    public int BaseB => 0x4768E78;

    public PointerInfo DeathNum => new()
    {
        Base = BaseA,
        Offsets = new[] { 0x98 }
    };

    public PointerInfo Hp => new()
    {
        Base = BaseB,
        Offsets = new[] { 0x80, 0x1F90, 0x18, 0xD8 }
    };
}
