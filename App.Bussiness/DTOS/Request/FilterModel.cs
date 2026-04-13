using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Request
{
    public class FilterModel<T>
    {
        public T Filter { get; set; }
        public string SortByParam { get; set; }
        public string SortOrderBy { get; set; }
        public int PageSize { get; set; } = 0;
        public int PageNumber { get; set; } = 0;
        public FilterModel() { }
        public FilterModel(int pIndex, int pSize, T filter)
        {
            Filter = filter;
            PageSize = pSize;
            PageNumber = pIndex;
        }

        [JsonIgnore]
        public int Offset
        {
            get
            {
                var index = PageNumber - 1 < 0 ? 0 : PageNumber - 1;
                return index * PageSize;
            }
        }
    }
}
