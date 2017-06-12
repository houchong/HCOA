using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mianshi
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public override QuestionType questiontype
        {
            get
            {
               return QuestionType.MultipleChoice;
            }
        }
        public override string GetQuestionAnswer()
        {
            return "单选答案";
        }
    }
}
