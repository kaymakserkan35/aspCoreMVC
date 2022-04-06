using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelProjesi.Models
{
    public class CreateExcelMessage
    {
        public int UserId { get; set; }
        public int FileId { get; set; }
    }
}
