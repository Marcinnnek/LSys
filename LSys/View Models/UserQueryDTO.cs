using LSys_DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys.DTOs
{
    public class UserQueryDTO
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
