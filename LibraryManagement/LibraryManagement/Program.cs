using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.AggregationOperations;
using LibraryManagement.Datamodels;
using LibraryManagement.ObjectToListConverter;
using LibraryManagement.ReadWriteOperations;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string filePath1 = "C:\\Users\\Bhanu Singh\\source\\repos\\PracticeProgramProject\\FileHandlingProject4" +
                                     "\\LibraryManagement\\LibraryManagement\\DataSourceFiles\\BookData.csv";
            const string filePath2 = "C:\\Users\\Bhanu Singh\\source\\repos\\PracticeProgramProject\\FileHandlingProject4" +
                                     "\\LibraryManagement\\LibraryManagement\\DataSourceFiles\\BookRental.csv";
            const string filePath3 = "C:\\Users\\Bhanu Singh\\source\\repos\\PracticeProgramProject\\FileHandlingProject4" +
                                     "\\LibraryManagement\\LibraryManagement\\DataSourceFiles\\BookIssued.csv";
            const string filePath4 = "C:\\Users\\Bhanu Singh\\source\\repos\\PracticeProgramProject\\FileHandlingProject4" +
                                     "\\LibraryManagement\\LibraryManagement\\DataSourceFiles\\ReturnIssuedData.csv";

            BookDataOperations bookDataOperations = new BookDataOperations();
            //List<BookIssuedDO> bookIssuedDOs = bookDataOperations.getDataOfIssuedBook(filePath1, filePath2);

            ListCreationFromObject listCreationFromObject = new ListCreationFromObject();
            //List<List<string>> listData1 = listCreationFromObject.getListFromObject(bookIssuedDOs);

            WriteOnFile writeOnFile = new WriteOnFile();
            //writeOnFile.writeOnSourceFile(listData1, filePath3);

            List<ReturnedIssuedDO> returnedIssuedDOs = bookDataOperations.getDataOfTwoOrMoreIssuedReturns(filePath1, filePath2);
            List < List<string> > listData2 = listCreationFromObject.getListFromObject(returnedIssuedDOs);
            writeOnFile.writeOnSourceFile(listData2 , filePath4);
        }
    }
}
