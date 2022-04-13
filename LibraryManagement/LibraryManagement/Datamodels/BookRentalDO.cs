using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Datamodels
{
    public class BookRentalDO
    {
        public int userId;
        public string userName;
        public int bookId;
        public DateTime bookIssueDate;
        public DateTime bookReturnDate;
        public bool bookIssued;
        public int userPincode;

    }
}
