﻿using Syncfusion.Blazor;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Adapter
{
    public interface IAPIAccountsAdapter
    {

        Task<object> InsertAsync(DataManager dataManager, object data, string key);
        object Read(DataManagerRequest dataManager, string key = null);
        Task<object> RemoveAsync(DataManager dataManager, object id, string keyField, string key);
        Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key);
    }
}