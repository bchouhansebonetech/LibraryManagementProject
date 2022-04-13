using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Datamodels;

namespace LibraryManagement.ObjectToListConverter
{
    public class ListCreationFromObject
    {
        public List<List<string>> getListFromObject(List<BookIssuedDO> bookIssuedDOs)
        {
            List<List<string>> list = new List<List<string>>();
            foreach (BookIssuedDO bookIssuedDO in bookIssuedDOs)
            {
                List<string> listItem = new List<string>();
                listItem.Add(bookIssuedDO.bookId.ToString());
                listItem.Add(bookIssuedDO.bookName.ToString());
                listItem.Add(bookIssuedDO.bookIssued.ToString());
                listItem.Add(bookIssuedDO.bookIssuedUserName.ToString());
                listItem.Add(bookIssuedDO.bookIssuedDate.ToString());
                list.Add(listItem);
            }
            return list;
        }

        public List<List<string>> getListFromObject(List<ReturnedIssuedDO> bookIssuedDOs)
        {
            List<List<string>> list = new List<List<string>>();
            foreach(ReturnedIssuedDO returnedIssuedDO in bookIssuedDOs)
            {
                List<string> listItem = new List<string>();
                listItem.Add(returnedIssuedDO.bookIssuedUserName.ToString());
                listItem.Add(returnedIssuedDO.numberOfIssued.ToString());
                listItem.Add(returnedIssuedDO.numberOfReturns.ToString());
                list.Add(listItem);
            }
            return list;
        }
    }
}
