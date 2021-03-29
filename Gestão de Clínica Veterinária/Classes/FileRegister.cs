using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Gestão_de_Clínica_Veterinária.Classes
{
    class FileRegister
    {

        private string Path;

        public FileRegister()
        {
            this.Path = AppDomain.CurrentDomain.BaseDirectory;
        }

        public bool newOwner(Owner owner)
        {
            bool created;
            string path = Path + @"\Resources\Clients\" + owner.Id + @".txt";

            try
            {
                using (FileStream fs = File.Create(Path))
                {
                    created = fs == null ? false : true;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                created = false;
            }

            return created;
        }
    }
}
