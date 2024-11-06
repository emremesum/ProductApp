using System;
using System.Collections.Generic;


namespace ProductApp.DataAccess;

public class ConnectionStringOption
{

    public const string Key = "ConnectionStrings";
    public string SqlServer { get; set; } = default!;
}
