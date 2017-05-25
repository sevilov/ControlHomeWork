using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ControlHomeWork
{
    [Serializable]
    public class NoteInfo
    {
        public DateTime Date
        {
            get;
            set;
        }
       
        public NoteInfo()
        {

        }
      
        public string Note { get; set; }
        public int Priority { get; set; }
        public NoteInfo( DateTime date, string note, int priority)
        {
            Date = date.Date;
            Note = note;
            Priority = priority;
        }
    } 
}
