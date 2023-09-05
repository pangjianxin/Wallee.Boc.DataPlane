using System;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses.Dtos;

public class CcicAddressKey
{
    public string CUSNO { get; set; } = default!;

    public string LGPER_CODE { get; set; } = default!;
}