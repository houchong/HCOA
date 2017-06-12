using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mianshi
{
    public class TextQuestion : QuestionBase
    {
        public override QuestionType questiontype
        {
            get
            {
                return QuestionType.Text;
            }
        }

        public override string GetQuestionAnswer()
        {
            return "文本答案";
        }
    }
}
