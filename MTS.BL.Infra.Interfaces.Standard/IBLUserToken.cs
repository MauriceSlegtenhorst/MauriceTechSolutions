﻿using System;

namespace MTS.BL.Infra.Interfaces.Standard
{
    public interface IBLUserToken
    {
        DateTime Expiration { get; set; }
        string LoginProvider { get; set; }
        string Name { get; set; }
        string UserId { get; set; }
        string Value { get; set; }
    }
}