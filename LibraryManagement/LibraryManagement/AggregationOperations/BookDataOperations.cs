using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibraryManagement.Datamodels;
using LibraryManagement.ReadWriteOperations;

namespace LibraryManagement.AggregationOperations
{
    public class BookDataOperations
    {
        public List<BookIssuedDO> getDataOfIssuedBook(string filePath1, string filePath2)
        {
            ReadFile readFile = new ReadFile(); 
            List<BookDataDO> bookDataDOs = readFile.getBookDataFromFile(filePath1);
            List<BookRentalDO> bookRentalDOs = readFile.getBookRentalDataFromFile(filePath2);
            List<BookIssuedDO> bookIssuedDOs = new List<BookIssuedDO>();
            Dictionary<int, string> bookNameById = new Dictionary<int, string>();

            foreach (BookDataDO bookDataDO in bookDataDOs)
                bookNameById[bookDataDO.bookId] = bookDataDO.bookName;

            foreach(BookRentalDO bookRentalDO in bookRentalDOs)
            {
                if (bookRentalDO.bookIssued)
                {
                    BookIssuedDO bookIssuedDO = new BookIssuedDO();
                    bookIssuedDO.bookId = bookRentalDO.bookId;
                    bookIssuedDO.bookName = bookNameById[bookRentalDO.bookId];
                    bookIssuedDO.bookIssued = bookRentalDO.bookIssued;
                    bookIssuedDO.bookIssuedUserName = bookRentalDO.userName;
                    bookIssuedDO.bookIssuedDate = bookRentalDO.bookIssueDate;
                    
                    bookIssuedDOs.Add(bookIssuedDO);
                }
            }

            return bookIssuedDOs;
        }

        public List<ReturnedIssuedDO> getDataOfTwoOrMoreIssuedReturns(string filePath1, string filePath2)
        {
            {
                //ReadFile readFile = new ReadFile();
                //List<BookRentalDO> bookRentalDOs = readFile.getBookRentalDataFromFile(filePath2);
                //Dictionary<string, int> nameAndNoOfIssued = new Dictionary<string, int>();
                //Dictionary<string, int> nameAndNoOfReturns = new Dictionary<string, int>();
                //List<ReturnedIssuedDO> returnedIssuedDOs = new List<ReturnedIssuedDO>();

                //foreach (BookRentalDO bookRentalDO in bookRentalDOs)
                //{
                //    if (nameAndNoOfIssued.ContainsKey(bookRentalDO.userName))
                //    {
                //        nameAndNoOfIssued[bookRentalDO.userName]++;
                //    }
                //    else
                //        nameAndNoOfIssued.Add(bookRentalDO.userName, 1);
                //}


                //foreach (BookRentalDO bookRentalDO in bookRentalDOs)
                //{
                //    if (!bookRentalDO.bookIssued)
                //    {
                //        if (nameAndNoOfReturns.ContainsKey(bookRentalDO.userName))
                //        {
                //            nameAndNoOfReturns[bookRentalDO.userName]++;
                //        }
                //        else
                //            nameAndNoOfReturns.Add(bookRentalDO.userName, 1);
                //    }
                //}

                //foreach (BookRentalDO bookRentalDO in bookRentalDOs)
                //{
                //    if (nameAndNoOfReturns.ContainsKey(bookRentalDO.userName) &&
                //       (nameAndNoOfIssued[bookRentalDO.userName] >1 || nameAndNoOfReturns[bookRentalDO.userName] >1))
                //    {
                //        ReturnedIssuedDO returnedIssuedDO = new ReturnedIssuedDO();
                //        returnedIssuedDO.bookIssuedUserName = bookRentalDO.userName;
                //        returnedIssuedDO.numberOfIssued = nameAndNoOfIssued[bookRentalDO.userName];
                //        returnedIssuedDO.numberOfReturns = nameAndNoOfReturns[bookRentalDO.userName];
                //        returnedIssuedDOs.Add(returnedIssuedDO);
                //        nameAndNoOfReturns.Remove(bookRentalDO.userName);
                //        nameAndNoOfIssued.Remove(bookRentalDO.userName);
                //    }

                //}
                //return returnedIssuedDOs;
            }

            ReadFile readFile = new ReadFile();
            List<BookRentalDO> bookRentalDOs = readFile.getBookRentalDataFromFile(filePath2);
            Dictionary<string, ReturnedIssuedDO> keyValuePairs = new Dictionary<string, ReturnedIssuedDO>();
            List<ReturnedIssuedDO> returnedIssuedDOs = new List<ReturnedIssuedDO>();

            foreach(BookRentalDO bookRentalDO in bookRentalDOs)
            {
                if (keyValuePairs.ContainsKey(bookRentalDO.userName))
                {
                    keyValuePairs[bookRentalDO.userName].numberOfIssued++;
                    if (!bookRentalDO.bookIssued) 
                        keyValuePairs[bookRentalDO.userName].numberOfReturns++;
                }
                else
                {
                    keyValuePairs.Add(bookRentalDO.userName, new ReturnedIssuedDO());
                    keyValuePairs[bookRentalDO.userName].bookIssuedUserName = bookRentalDO.userName;
                    keyValuePairs[bookRentalDO.userName].numberOfIssued++;
                    if(!bookRentalDO.bookIssued)
                        keyValuePairs[bookRentalDO.userName].numberOfReturns++;
                }
            }

            foreach(var str in keyValuePairs.Keys)
                if(keyValuePairs[str].numberOfIssued > 1 || keyValuePairs[str].numberOfReturns > 1)
                    returnedIssuedDOs.Add(keyValuePairs[str]);

            return returnedIssuedDOs;
        }
    }
}
