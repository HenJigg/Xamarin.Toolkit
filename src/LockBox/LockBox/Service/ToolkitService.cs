using Toolkit.Core;
using Toolkit.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkit.Service
{
    public class ToolkitService : IToolkitService
    {
        public async Task<bool> AddToolkitDetail(ToolkitDetail detail)
        {
            App.Instance.ToolkitDetails.Add(detail);
            return await App.Instance.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteToolkitDetail(int id)
        {
            var detail = await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => Equals(t.Id, id));
            if (detail != null)
            {
                App.Instance.ToolkitDetails.Remove(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteToolkitMasterById(int id)
        {
            var detail = await App.Instance.ToolkitMasters.FirstOrDefaultAsync(t => Equals(t.Id, id));
            if (detail != null)
            {
                App.Instance.ToolkitMasters.Remove(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<ToolkitDetail> GetToolkitDetailByIdAsync(int id)
        {
            return await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<ToolkitDetail>> GetToolkitDetailsAsync(int id)
        {
            return await App.Instance.ToolkitDetails.Where(t => Equals(t.MasterId, id)).ToListAsync();
        }

        public async Task<ToolkitMaster> GetToolkitMasterByIdAsync(int id)
        {
            return await App.Instance.ToolkitMasters.FirstOrDefaultAsync(t => Equals(t.Id, id));
        }

        public async Task<List<ToolkitMaster>> GetToolkitMastersAsync()
        {
            return await App.Instance.ToolkitMasters.ToListAsync();
        }

        public async Task<bool> UpdateToolkitDetail(ToolkitDetail detail)
        {
            var model = await App.Instance.ToolkitDetails.FirstOrDefaultAsync(t => Equals(t.Id, detail.Id));
            if (model != null)
            {
                model.Name = detail.Name;
                model.PassWord = detail.PassWord;
                model.Account = detail.Account;
            }
            return await App.Instance.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateToolkitMater(ToolkitMaster boxMaster)
        {
            var model = await App.Instance.ToolkitMasters.FirstOrDefaultAsync(t => Equals(t.Id, boxMaster.Id));
            if (model != null)
            {
                model.GroupIcon = boxMaster.GroupIcon;
                model.GroupName = boxMaster.GroupName;
                model.GroupDesc = boxMaster.GroupDesc;
            }
            return await App.Instance.SaveChangesAsync() > 0;
        }
    }
}
