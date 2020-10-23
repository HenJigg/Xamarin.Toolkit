using LockBox.Core;
using LockBox.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockBox.Service
{
    public class LockBoxService : ILockBoxService
    {
        public async Task<bool> DeleteLockBoxDetail(int id)
        {
            var detail = await App.Instance.LockBoxDetails.FirstOrDefaultAsync(t => Equals(t.Id, id));
            if (detail != null)
            {
                App.Instance.LockBoxDetails.Remove(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteLockBoxMasterById(int id)
        {
            var detail = await App.Instance.LockBoxMasters.FirstOrDefaultAsync(t => Equals(t.Id, id));
            if (detail != null)
            {
                App.Instance.LockBoxMasters.Remove(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<LockBoxDetail>> GetLockBoxDetailsAsync(int id)
        {
            return await App.Instance.LockBoxDetails.Where(t => Equals(t.Id, id)).ToListAsync();
        }

        public async Task<LockBoxMaster> GetLockBoxMasterByIdAsync(int id)
        {
            return await App.Instance.LockBoxMasters.FirstOrDefaultAsync(t => Equals(t.Id, id));
        }

        public async Task<List<LockBoxMaster>> GetLockBoxMastersAsync()
        {
            return await App.Instance.LockBoxMasters.ToListAsync();
        }

        public async Task<bool> UpdateLockBoxDetail(LockBoxDetail detail)
        {
            var model = await App.Instance.LockBoxDetails.FirstOrDefaultAsync(t => Equals(t.Id, detail.Id));
            if (model != null)
            {
                model.Name = detail.Name;
                model.PassWord = detail.PassWord;
                model.Account = detail.Account;
            }
            return await App.Instance.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLockBoxMater(LockBoxMaster boxMaster)
        {
            var model = await App.Instance.LockBoxMasters.FirstOrDefaultAsync(t => Equals(t.Id, boxMaster.Id));
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
