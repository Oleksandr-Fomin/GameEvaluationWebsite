using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
