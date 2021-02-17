using Project_1.AppServices.UserInputAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.AppServices.UserInputAppService
{
    public interface IUsers
    {
        //this method procces user's question and returns appropriate answer
        string UsersInputProcessing(UsersInput input);

        //adds new questions and answers
        void Registration(UsersInput input);

        //this method takes all data from Users table and returns it as a list to print them on the screen 
        List<QuestionsOutput> Output();

        //deletes row with Id
        void Delete(int Id);

        //this method returns the row from Users if it contaions specific Id
        UsersInput Edit(int Id);

        //this method lets you to change question or answer
        void Update(string answer, string question, int Id);
    }
}
