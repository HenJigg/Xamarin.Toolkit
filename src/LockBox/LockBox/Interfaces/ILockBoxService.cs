using Toolkit.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Toolkit.Interfaces
{
    public interface IToolkitService
    {
        Task<List<ToolkitMaster>> GetToolkitMastersAsync();

        Task<ToolkitMaster> GetToolkitMasterByIdAsync(int id);

        Task<bool> DeleteToolkitMasterById(int id);

        Task<bool> UpdateToolkitMater(ToolkitMaster boxMaster);

        Task<List<ToolkitDetail>> GetToolkitDetailsAsync(int id);

        Task<ToolkitDetail> GetToolkitDetailByIdAsync(int id);

        Task<bool> AddToolkitDetail(ToolkitDetail detail);

        Task<bool> UpdateToolkitDetail(ToolkitDetail detail);

        Task<bool> DeleteToolkitDetail(int id);
    }
}
