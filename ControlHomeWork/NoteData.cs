using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlHomeWork
{
    public class NoteData
    {
        private List<NoteInfo> _listinfo;
        public List<NoteInfo> NotesInfo
        {
            get { return _listinfo; }
            set { _listinfo = value; }
        }
    }
}
