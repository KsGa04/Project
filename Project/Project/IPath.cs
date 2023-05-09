using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
