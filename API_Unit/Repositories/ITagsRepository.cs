using System.Collections.Generic;
using System.Threading.Tasks;
using API_Unit.Models;

namespace API_Unit.Repositories
{
    public interface ITagsRepository
    {
        /// <summary>
        /// لیست تگ کارت ها
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tags> GetAllTags();
        /// <summary>
        /// افزودن تگ کارت جدید
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<Tags> Add(Tags tag);
        /// <summary>
        /// بروزرسانی تگ کارت
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<Tags> Update(Tags tag);
        /// <summary>
        /// حذف تگ کارت 
        /// </summary>
        /// <param name="tagid">شناسه تگ</param>
        /// <returns></returns>
        Task<Tags> Remove(int tagid);
        /// <summary>
        /// جستجوی تگ کارت
        /// </summary>
        /// <param name="tagid"></param>
        /// <returns></returns>
        Task<Tags> Find(int tagid);
        /// <summary>
        /// صحت وجود شناسه تگ
        /// </summary>
        /// <param name="tagid"></param>
        /// <returns></returns>
        Task<bool> IsExists(int tagid);
    }
}