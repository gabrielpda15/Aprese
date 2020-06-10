using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Repository.Interfaces
{
    public interface IUserContextLoader
    {
        void LoadData(IUserContext userContext);
    }
}
