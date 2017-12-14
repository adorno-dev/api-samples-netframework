using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Samples.Domain.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Text { get; set; }

        public bool Done { get; set; }
    }
}
