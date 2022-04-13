using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Datamodels;
using System.IO;

namespace LibraryManagement.ReadWriteOperations
{
    public class ReadFile
    {
        public List<BookDataDO> getBookDataFromFile(string filePath)
        {
            List<BookDataDO> bookData = new List<BookDataDO>();

            using(StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    BookDataDO bookDataDO = new BookDataDO();   
                    bookDataDO.bookId = Convert.ToInt32(values[0]);
                    bookDataDO.bookName = values[1];
                    bookDataDO.bookAuthor = values[2];
                    bookDataDO.isbnNumber = values[3];
                    bookDataDO.bookPrice = Convert.ToInt32(values[4]);

                    bookData.Add(bookDataDO);
                }
            }
            return bookData;
        }

        public List<BookRentalDO> getBookRentalDataFromFile(string filePath)
        {
            List<BookRentalDO> bookRentalData = new List<BookRentalDO>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    BookRentalDO bookRentalDO = new BookRentalDO();
                    bookRentalDO.userId = Convert.ToInt32(values[0]);
                    bookRentalDO.userName = values[1]; 
                    bookRentalDO.bookId= Convert.ToInt32(values[2]);
                    bookRentalDO.bookIssueDate = Convert.ToDateTime(values[3]);
                    bookRentalDO.bookReturnDate = Convert.ToDateTime(values[4]);
                    bookRentalDO.bookIssued = Convert.ToBoolean(values[5]); 
                    bookRentalDO.userPincode = Convert.ToInt32(values[6]);

                    bookRentalData.Add(bookRentalDO);
                }
            }
            return bookRentalData; 
        }
    }
}
