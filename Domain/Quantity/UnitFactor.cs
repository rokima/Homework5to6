﻿using Abc.Data.Quantity;
using Abc.Domain.Common;

namespace Abc.Domain.Quantity
{
    public sealed class UnitFactor: Entity<UnitFactorData>
    {
        public UnitFactor() : this(null) { }
        public UnitFactor(UnitFactorData data) : base(data) { }
    }
}
