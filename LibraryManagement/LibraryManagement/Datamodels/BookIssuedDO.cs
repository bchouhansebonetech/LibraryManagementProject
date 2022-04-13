using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Datamodels
{
    public class BookIssuedDO
    {
        public int bookId;
        public string bookName;
        public bool bookIssued;
        public string bookIssuedUserName;
        public DateTime bookIssuedDate;
    }
}
