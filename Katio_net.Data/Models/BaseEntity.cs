using System;

namespace Katio_net.Data.Models;

public class BaseEntity<TId> where TId : struct
{
    public TId Id {get;set;}
}
