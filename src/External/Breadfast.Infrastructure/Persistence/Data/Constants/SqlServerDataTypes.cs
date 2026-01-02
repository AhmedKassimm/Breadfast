using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadfast.Infrastructure.Persistence.Data.Constants
{
    public class SqlServerDataTypes
    {
        public static readonly string Shortvarchar = "varchar(50)";
        public static readonly string Varchar = "varchar(100)";
        public static readonly string Money = "money";
        public static readonly string Float = "float";
        public static readonly string DateTime = "datetime";
        public static readonly string Date = "date";
        public static readonly string Decimal = "decimal(18,2)";
        public static readonly string Bigvarchar = "varchar(max)";


    }
}
