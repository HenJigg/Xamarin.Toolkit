using LockBox.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockBox.Interfaces
{
    public interface ILockBoxService
    {
        Task<List<LockBoxMaster>> GetLockBoxMastersAsync();

        Task<LockBoxMaster> GetLockBoxMasterByIdAsync(int id);

        Task<bool> DeleteLockBoxMasterById(int id);

        Task<bool> UpdateLockBoxMater(LockBoxMaster boxMaster);

        Task<List<LockBoxDetail>> GetLockBoxDetailsAsync(int id);

        Task<bool> UpdateLockBoxDetail(LockBoxDetail detail);

        Task<bool> DeleteLockBoxDetail(int id);
    }
}
