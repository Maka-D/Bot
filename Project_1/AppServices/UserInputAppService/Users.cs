using Project_1.AppServices.UserInputAppService.DTOs;
using Project_1.Core;
using Project_1.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.AppServices.UserInputAppService
{
    public class Users : IUsers
    {
        //dependency injection to database
        private readonly AppDbContext _regRepository;
        public Users(AppDbContext regRepository)
        {
            _regRepository = regRepository;
       
        }
        //this method takes all data from Users table and returns it as a list to print them on the screen 
        public List<QuestionsOutput> Output()
        {
            var result = _regRepository.Users.OrderByDescending(x=>x.CreationTime);
            List<QuestionsOutput> output = new List<QuestionsOutput>();
            foreach(var item in result)
            {
                QuestionsOutput A = new QuestionsOutput();
                A.Id = item.Id;
                A.Question = item.UsersQuestion;
                A.Answer = item.Answer;
                A.DateTime = item.CreationTime;
                output.Add(A);

            }
            return output;
        }
        //delete with Id
        public void Delete(int Id)
        {
            var result = _regRepository.Users.Where(x=>x.Id == Id).FirstOrDefault();
            _regRepository.Users.Remove(result);
            _regRepository.SaveChanges();
        }
        //adds new questions and answers
        public void Registration(UsersInput input)
        {
            if(input.Answer != null && input.Question != null)
            {
                //checks on symbols 
                if (CheckSymbols(input))
                {
                    //if questions doesn't match adds new row to Users table
                     if(!_regRepository.Users.Any(x=>x.UsersQuestion == input.Question))                   
                     {
                      UsersCore user = new UsersCore();
                      user.UsersQuestion = input.Question.Trim();
                      user.Answer = input.Answer.Trim();
                      _regRepository.Users.Add(user);
                      _regRepository.SaveChanges();
                     }
                }

            }
            
        }

        //this method procces user's question and returns appropriate answer
        public string UsersInputProcessing(UsersInput input)
        {
            if(input.Question != null)
            {
                if(_regRepository.Users.Any(x=> x.UsersQuestion == input.Question))
                {
                    var user = _regRepository.Users.Where(x => x.UsersQuestion == input.Question).FirstOrDefault();
                    return user.Answer;
                }
                return "Can't Find!";
                
            }
            else
            {
                return "False";
            }
            
        }
        //checks if user's input contains allowed characters
        private bool CheckSymbols(UsersInput input)
        {
            char[] GeoSymbols = { ' ','ა', 'ბ', 'გ', 'დ', 'ე', 'ვ', 'ზ', 'თ', 'ი', 'კ', 'ლ', 'მ', 'ნ', 'ო', 'პ', 'ჟ', 'რ', 'ს', 'ტ', 'უ', 'ფ', 'ქ', 'ღ', 'ყ', 'შ', 'ჩ', 'ც', 'ძ', 'წ', 'ჭ', 'ხ', 'ჯ', 'ჰ', ':', ';', ',', '.',  '!', '(', ')','?' };
            bool checkQuestion = false;
            bool checkAnswer = false;
            char[] inputQuestionSymbols = (input.Question).ToCharArray();
            char[] inputAnswerSymbols = (input.Answer).ToCharArray();
            foreach (var item in inputQuestionSymbols)
            {
                if (Enumerable.Contains(GeoSymbols, item))
                {
                    checkQuestion = true;
                }               
                
            }
            foreach (var item in inputAnswerSymbols)
            {
                if (Enumerable.Contains(GeoSymbols, item))
                {
                    checkAnswer = true;
                }

            }
            if (checkQuestion == true && checkAnswer == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        //this method returns the row from Users if it contaions specific Id
        public UsersInput Edit(int Id)
        {
            if(_regRepository.Users.Any(x=> x.Id == Id))
            {
                UsersInput user = new UsersInput();
                var u = _regRepository.Users.Where(x => x.Id == Id).FirstOrDefault();
                user.Id = u.Id;
                user.Answer = u.Answer;
                user.Question = u.UsersQuestion;
                return user;
            }
            else
            {
                return new UsersInput();
            }
        }
        //this method lets you to change question or answer
        public void Update(string answer, string question, int Id)
        {
           if( checkAnswersAndQuestions(answer, question))
            {
                var user = _regRepository.Users.Where(x => x.Id == Id).FirstOrDefault();
                user.UsersQuestion = question;
                user.Answer = answer;
                _regRepository.SaveChanges();

            }
        }
        //this method checks if Users table contains row with defined question and answer
        private bool checkAnswersAndQuestions(string answer, string question)
        {
            if(_regRepository.Users.Any(x=>x.Answer == answer && x.UsersQuestion == question))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
