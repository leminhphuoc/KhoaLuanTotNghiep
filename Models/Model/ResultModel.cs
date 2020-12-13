using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ResultModel<T>
    {
        public T Value { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
