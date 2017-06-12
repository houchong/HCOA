using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mianshi
{
    public abstract class QuestionBase : IQuestion
    {
        public abstract QuestionType questiontype
        {
            get;
        }
        public string title
        {
            get;set;
        }
        public virtual string GetQuestionAnswer()
        {
            return "默认答案";
        }
    }
}
