using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Lưu tất cả các thay đổi đã thực hiện trong ngữ cảnh này vào cơ sở dữ liệu.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Bắt đầu một giao dịch cơ sở dữ liệu mới.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Cam kết giao dịch hiện tại.
        /// </summary>
        void Commit();

        /// <summary>
        /// Hoàn tác giao dịch hiện tại.
        /// </summary>
        void Rollback();
    }
}
