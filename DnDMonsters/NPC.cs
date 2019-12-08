using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDMonsters
{
    class NPC
    {
        private string _name;
        private int _ac;
        private int _dex;
        private string _town;
        #region
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int AC
        {
            get { return _ac; }
            set { _ac = value; }
        }
        public int Dex
        {
            get { return _dex; }
            set { _dex = value; }
        }
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }
        public NPC()
        {

        }
        public NPC(string name, int ac)
        {
            _name = name;
            _ac = ac;
        }
            #endregion
        }
}
