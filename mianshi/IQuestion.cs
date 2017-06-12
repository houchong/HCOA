using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mianshi
{
   public interface IQuestion
    {
        string title { get; set; }
        QuestionType questiontype { get; }
        string GetQuestionAnswer();
    }
}
