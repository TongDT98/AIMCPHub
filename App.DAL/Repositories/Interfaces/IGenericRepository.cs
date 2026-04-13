using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Interfaces
{
   public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định.
        /// </summary>
        IQueryable<T> Queryable();

        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định bao gồm cả các thực thể đã bị xóa mềm.
        /// </summary>
        IQueryable<T> QueryableAll();

        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định mà không theo dõi các thay đổi.
        /// </summary>
        IQueryable<T> AsNoTracking();

        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định với hỗ trợ localization và không theo dõi các thay đổi.
        /// </summary>
        IQueryable<T> WithLocalizationNoTracking();

        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định với hỗ trợ localization, không theo dõi các thay đổi, bao gồm cả các thực thể đã bị xóa mềm.
        /// </summary>
        IQueryable<T> WithLocalizationNoTrackingAll();

        /// <summary>
        /// Trả về một IQueryable của loại T được chỉ định mà không theo dõi các thay đổi, bao gồm cả các thực thể đã bị xóa mềm.
        /// </summary>
        IQueryable<T> AsNoTrackingAll();

        /// <summary>
        /// Xóa mềm thực thể được chỉ định và tùy chọn ghi lại ID của người dùng thực hiện hành động.
        /// </summary>
        /// <param name="entity">Thực thể cần xóa mềm.</param>
        /// <param name="userId">ID của người dùng thực hiện hành động.</param>
        /// <returns>True nếu xóa mềm thành công; ngược lại False.</returns>
        bool SoftDelete(T entity, Guid? userId);

        /// <summary>
        /// Lấy một thực thể duy nhất khớp với biểu thức được cung cấp.
        /// </summary>
        /// <param name="expression">Biểu thức để lọc thực thể.</param>
        /// <returns>Thực thể nếu tìm thấy; ngược lại là null.</returns>
        T? Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Lấy tất cả các thực thể của loại T.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy tất cả các thực thể của loại T khớp với biểu thức được cung cấp.
        /// </summary>
        /// <param name="expression">Biểu thức để lọc thực thể.</param>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Thêm một thực thể mới vào kho lưu trữ và tùy chọn ghi lại ID của người dùng thực hiện hành động.
        /// </summary>
        /// <param name="entity">Thực thể cần thêm.</param>
        /// <param name="userId">ID của người dùng thực hiện hành động.</param>
        void Add(T entity, Guid? userId = null);

        /// <summary>
        /// Thêm nhiều thực thể mới vào kho lưu trữ và tùy chọn ghi lại ID của người dùng thực hiện hành động.
        /// </summary>
        /// <param name="entities">Các thực thể cần thêm.</param>
        /// <param name="userId">ID của người dùng thực hiện hành động.</param>
        void AddRange(IEnumerable<T> entities, Guid? userId = null);

        /// <summary>
        /// Thêm nhiều thực thể mới vào kho lưu trữ một cách gọn gàng.
        /// </summary>
        /// <param name="entities">Các thực thể cần thêm.</param>
        void AddRangeCompact(IEnumerable<T> entities);

        /// <summary>
        /// Loại bỏ thực thể được chỉ định khỏi kho lưu trữ.
        /// </summary>
        /// <param name="entity">Thực thể cần loại bỏ.</param>
        void Remove(T entity);

        /// <summary>
        /// Loại bỏ nhiều thực thể khỏi kho lưu trữ.
        /// </summary>
        /// <param name="entities">Các thực thể cần loại bỏ.</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Cập nhật thực thể được chỉ định trong kho lưu trữ và tùy chọn ghi lại ID của người dùng thực hiện hành động.
        /// </summary>
        /// <param name="entity">Thực thể cần cập nhật.</param>
        /// <param name="userId">ID của người dùng thực hiện hành động.</param>
        void Update(T entity, Guid? userId = null);

        /// <summary>
        /// Cập nhật nhiều thực thể trong kho lưu trữ.
        /// </summary>
        /// <param name="entities">Các thực thể cần cập nhật.</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Lấy một thực thể duy nhất khớp với biểu thức được cung cấp một cách bất đồng bộ.
        /// </summary>
        /// <param name="expression">Biểu thức để lọc thực thể.</param>
        /// <param name="cancellationToken">Token hủy bỏ.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ. Kết quả của tác vụ chứa thực thể nếu tìm thấy; ngược lại là null.</returns>
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lấy tất cả các thực thể của loại T một cách bất đồng bộ.
        /// </summary>
        /// <param name="cancellationToken">Token hủy bỏ.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ. Kết quả của tác vụ chứa danh sách các thực thể.</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Lấy tất cả các thực thể của loại T khớp với biểu thức được cung cấp một cách bất đồng bộ.
        /// </summary>
        /// <param name="expression">Biểu thức để lọc thực thể.</param>
        /// <param name="cancellationToken">Token hủy bỏ.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ. Kết quả của tác vụ chứa danh sách các thực thể.</returns>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        /// <summary>
        /// Thêm một thực thể mới vào kho lưu trữ một cách bất đồng bộ và tùy chọn ghi lại ID của người dùng thực hiện hành động.
        /// </summary>
        /// <param name="entity">Thực thể cần thêm.</param>
        /// <param name="userId">ID của người dùng thực hiện hành động.</param>
        /// <param name="cancellationToken">Token hủy bỏ.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ.</returns>
        Task AddAsync(T entity, Guid? userId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Thêm nhiều thực thể mới vào kho lưu trữ một cách bất đồng bộ.
        /// </summary>
        /// <param name="entities">Các thực thể cần thêm.</param>
        /// <param name="cancellationToken">Token hủy bỏ.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ.</returns>
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lưu các thay đổi vào kho lưu trữ.
        /// </summary>
        /// <returns>Số lượng các mục trạng thái được ghi vào cơ sở dữ liệu.</returns>
        int SaveChange();

        /// <summary>
        /// Lưu các thay đổi vào kho lưu trữ một cách bất đồng bộ.
        /// </summary>
        /// <returns>Một tác vụ đại diện cho hoạt động bất đồng bộ. Kết quả của tác vụ chứa số lượng các mục trạng thái được ghi vào cơ sở dữ liệu.</returns>
        Task<int> SaveChangeAsync();
    }
}
